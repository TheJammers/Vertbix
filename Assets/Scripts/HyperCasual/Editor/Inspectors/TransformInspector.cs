using System.Collections.Generic;
using System.Linq;
using HyperCasual.Editing.Components;
using HyperCasual.Editor.Utilities;
using HyperCasual.Extensions;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Inspectors
{
    [CustomEditor(typeof(Transform))]
    public class TransformInspector
        : UnityEditor.Editor
    {
        public static ObjectSpace Space;
        public static bool ShowComponents;
        public static bool ShowChildren;

        public override bool RequiresConstantRepaint()
        {
            ApplyLock();
            return base.RequiresConstantRepaint();
        }

        public override void OnInspectorGUI()
        {
            var transform = (Transform) target;
            DisplayHelpBox(transform);
            Space = (ObjectSpace)EditorGUILayout.EnumPopup("Space", Space);

            EditorGUI.BeginChangeCheck();
            var position = EditorGUILayout.Vector3Field("Position", transform.GetPosition(Space));
            var rotation = EditorGUILayout.Vector3Field("Rotation", transform.GetAngles(Space));
            var scale = EditorGUILayout.Vector3Field("Scale", transform.GetScale(Space));
            var removed = InspectComponents(transform);
            InspectChildren(transform);

            var change_recorded = EditorGUI.EndChangeCheck();
            if (change_recorded)
                UpdateTransform(transform, position, rotation, scale, removed);
        }

        private static void InspectChildren(Transform transform)
        {
            var children = transform.GetComponentsInChildren<Transform>(true).Where(element => element != transform).ToList();
            EditorGUILayout.BeginHorizontal();
            ShowChildren = EditorGUILayout.Foldout(ShowChildren, "Children");
            EditorGUILayout.IntField(children.Count, GUILayout.Width(50.0f));
            EditorGUILayout.EndHorizontal();
            if (!ShowChildren)
                return;

            EditorGUI.indentLevel += 1;
            foreach (var child in children)
                EditorGUILayout.ObjectField(child.name, child, typeof(Transform), true);

            EditorGUI.indentLevel -= 1;
        }

        private static Component InspectComponents(Transform transform)
        {
            var components = transform.GetComponents<Component>().Where(element => element != transform).ToList();
            EditorGUILayout.BeginHorizontal();
            ShowComponents = EditorGUILayout.Foldout(ShowComponents, "Components");
            EditorGUILayout.IntField(components.Count, GUILayout.Width(50.0f));
            EditorGUILayout.EndHorizontal();
            if (!ShowComponents)
                return null;

            EditorGUI.indentLevel += 1;
            var deleted = -1;
            for (var i = 0; i < components.Count; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                var component = components[i];
                component.hideFlags = (HideFlags) EditorGUILayout.EnumPopup(component.GetType().Name, component.hideFlags);
                deleted = InspectSideButton.Minus() ? i : deleted;
                EditorGUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel -= 1;
            return deleted == -1 ? null : components[deleted];
        }

        private void UpdateTransform(Transform transform, Vector3 position, Vector3 rotation, Vector3 scale, Component removed)
        {
            var lock_components = transform.GetComponents<ILockComponent>().ToList();

            Undo.RecordObject(transform, transform.name + "_transformed");
            if (!lock_components.Has<PositionLock>())
                transform.SetPosition(position, Space);

            if (!lock_components.Has<RotationLock>())
                transform.SetAngles(rotation, Space);

            if (Space == ObjectSpace.Local && !lock_components.Has<ScaleLock>())
                transform.SetScale(scale, Space);

            if (removed != null)
                Undo.DestroyObjectImmediate(removed);
        }

        private void ApplyLock()
        {
            if (EditorApplication.isPlaying)
                return;

            var transform = (Transform)target;
            var lock_components = transform.GetComponents<ILockComponent>().ToList();
            foreach (var lock_component in lock_components)
                lock_component.PerformLock();
        }

        private void DisplayHelpBox(Transform transform)
        {
            var lock_components = transform.GetComponents<ILockComponent>().ToList();
            if (lock_components.Count == 0)
                return;

            EditorGUILayout.HelpBox("Transform has locking components", MessageType.Warning);
        }
    }

    public static class LockComponentExtensions
    {
        public static bool Has<T>(this List<ILockComponent> list) where T : ILockComponent
        {
            return list.Exists(element => element is T);
        }
    }
}
