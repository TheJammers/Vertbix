using System.Collections.Generic;
using HyperCasual.Extensions;
using UnityEditor;
using UnityEngine;

namespace HyperCasual.Editor.Utilities
{
    /// <summary>
    /// Provides custom inspection of a Vector3 list treating it as an editable point list.
    /// </summary>
    public class InspectPointList
    {
        public static bool ShowPoints = true;
        public static bool ShowConnections = true;
        public bool DrawConnectionToOwner;
        public bool ShowItems = true;
        public int EditingPointIndex = -1;
        public Tool LastTool;
        public ObjectSpace Space;

        public InspectPointList SetSpace(ObjectSpace value)
        {
            Space = value;
            return this;
        }

        public InspectPointList SetDrawOwnerConnection(bool value)
        {
            DrawConnectionToOwner = value;
            return this;
        }

        public void OnSceneGUI<T>(T owner, List<Vector3> points) where T : Component
        {
            var transform = owner.transform;
            var world_offset = Space == ObjectSpace.Local ? Vector3.zero : transform.position;

            DrawPoints(points, world_offset, transform);
            DrawConnections(points, world_offset, transform);
            SceneView.RepaintAll();
            if (!ValidateEditingIndex(points))
                EditingPointIndex = -1;

            if (EditingPointIndex < 0)
                return;

            LastTool = Tools.current != Tool.None ? Tools.current : LastTool;
            Tools.current = Tool.None;
            var point = points[EditingPointIndex];

            Undo.RecordObject(owner, string.Format("{0}_point_move", owner.name));
            var position = point + world_offset;
            position = Handles.PositionHandle(position, Quaternion.identity);
            points[EditingPointIndex] = position - world_offset;
        }

        public void OnInspectorGUI<T>(T owner, List<Vector3> points) where T : Component
        {
            EditorGUILayout.BeginHorizontal();
            ShowItems = EditorGUILayout.Foldout(ShowItems, "Points");
            EditorGUILayout.IntField(points.Count, GUILayout.Width(50.0f));
            ShowConnections = InspectToggleButton.Perform("C", ShowConnections);
            ShowPoints = InspectToggleButton.Perform("P", ShowPoints);
            if (InspectSideButton.Plus())
            {
                Undo.RecordObject(owner, string.Format("{0}_point_add", owner.name));
                points.Add(Vector3.zero);
                ShowItems = true;
            }
            EditorGUILayout.EndHorizontal();
            if (!ShowItems)
                return;

            EditorGUI.indentLevel += 1;
            var deleted = -1;
            for (var i = 0; i < points.Count; ++i)
            {
                Undo.RecordObject(owner, string.Format("{0}_point_modified", owner.name));
                EditorGUILayout.BeginHorizontal();
                points[i] = EditorGUILayout.Vector3Field("Point", points[i]);
                deleted = InspectSideButton.Minus() ? i : deleted;

                var is_toggled = i == EditingPointIndex;
                var toggle = InspectToggleButton.Exclamation(is_toggled);
                if (toggle && !is_toggled)
                {
                    EditingPointIndex = i;
                    LastTool = Tools.current != Tool.None ? Tools.current : LastTool;
                    Tools.current = Tool.None;
                }

                if (!toggle && is_toggled)
                {
                    EditingPointIndex = -1;
                    Tools.current = LastTool != Tool.None ? LastTool : Tools.current;
                }

                EditorGUILayout.EndHorizontal();
            }

            if (deleted != -1)
            {
                Undo.RecordObject(owner, string.Format("{0}_point_remove", owner.name));
                points.RemoveAt(deleted);
            }

            EditorGUI.indentLevel -= 1;
        }

        private void DrawPoints(List<Vector3> points, Vector3 world_offset, Transform transform)
        {
            if (!ShowPoints)
                return;

            var handles_color = Handles.color;
            Handles.color = Color.green;
            foreach (var point in points)
            {
                var position = point + world_offset;
                Handles.SphereHandleCap(1, position, Quaternion.identity, HandleUtility.GetHandleSize(position)*0.2f, EventType.Repaint);
            }

            Handles.color = handles_color;
        }

        private void DrawConnections(List<Vector3> points, Vector3 world_offset, Transform transform)
        {
            if (!ShowConnections)
                return;

            var handles_color = Handles.color;
            Handles.color = Color.yellow;
            for (var i = 0; i < points.Count - 1; ++i)
                Handles.DrawLine(points[i] + world_offset, points[i + 1] + world_offset);

            if (DrawConnectionToOwner && !points.IsNullOrEmpty())
                Handles.DrawLine(transform.position, points[0] + world_offset);

            Handles.color = handles_color;
        }

        private bool ValidateEditingIndex(List<Vector3> points)
        {
            return points.Count > EditingPointIndex;
        }
    }
}
