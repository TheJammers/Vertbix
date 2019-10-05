using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownRace
{
    public class SegmentSnapperEditor : EditorWindow
    {
        public static Level Level { get; private set; }
        public static Segment[] Segments { get; private set; }


        [MenuItem("[GLD]/Segment Snapper")]
        static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(SegmentSnapperEditor));
            window.titleContent = new GUIContent("Segment Snapper");
            window.Show();
        }

        void OnEnable()
        {
            EditorSceneManager.sceneOpened += OnSceneOpened;
            EditorSceneManager.sceneClosing += OnSceneClosing;

            Populate();
        }

        void OnDisable()
        {
            EditorSceneManager.sceneOpened -= OnSceneOpened;
            EditorSceneManager.sceneClosing -= OnSceneClosing;
        }

        void OnHierarchyChange()
        {
            Populate();
        }

        public static void Populate()
        {
            if (Application.isPlaying)
                return;

            Debug.Log("GLD::Populate");
            SegmentSnapperEditor.Level = FindObjectOfType<Level>();
            SegmentSnapperEditor.Segments = FindObjectsOfType<Segment>();

            bool sceneDirty = false;
            foreach (var segment in SegmentSnapperEditor.Segments)
            {
                segment.Populate();

                var startPos = segment.transform.Find("StartPos");
                if (startPos != null)
                {
                    if (SegmentSnapperEditor.Level.start != segment)
                    {
                        SegmentSnapperEditor.Level.start = segment;
                        sceneDirty = true;
                    }
                    SegmentSnapperEditor.Level.startPos = startPos;
                }
                var finishlineTransform = segment.transform.Find("Finishline");
                if (finishlineTransform != null)
                {
                    if (SegmentSnapperEditor.Level.end != segment)
                    {
                        SegmentSnapperEditor.Level.end = segment;
                        sceneDirty = true;
                    }
                }
            }

            if (!sceneDirty)
                return;

            foreach (var scene in _loadedLevelScene)
            {
                EditorSceneManager.MarkSceneDirty(scene);
            }
        }

        static void OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            if (scene.name == "Game")
                return;
            _loadedLevelScene.Add(scene);
        }

        static void OnSceneClosing(Scene scene, bool removingScene)
        {
            if (scene.name == "Game")
                return;

            _loadedLevelScene.Remove(scene);
        }

        static List<Scene> _loadedLevelScene = new List<Scene>();
    }
}