﻿// Designed by KINEMATION, 2024.

using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace KINEMATION.ScriptableWidget
{
    public class ScriptableComponentEditorWindow : EditorWindow
    {
        private Editor _targetEditor;
        private Vector2 _scrollPosition;

        public static ScriptableComponentEditorWindow CreateWindow()
        {
            var newWindow = GetWindow<ScriptableComponentEditorWindow>(false, "Window", true);
            return newWindow;
        }

        public Editor GetEditor()
        {
            return _targetEditor;
        }

        public void RefreshEditor(Editor newEditor, string windowTitle)
        {
            titleContent.text = windowTitle;
            _targetEditor = newEditor;
            Assert.IsNotNull(_targetEditor);
        }

        public void OnGUI()
        {
            if (_targetEditor == null)
            {
                Close();
                return;
            }
            
            if (!EditorGUIUtility.wideMode)
            {
                EditorGUIUtility.wideMode = true;
            }
            
            GUIStyle paddedStyle = new GUIStyle()
            {
                // Set the padding you want (left, right, top, bottom)
                padding = new RectOffset(10, 0, 0, 0)
            };
            
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, paddedStyle);
            _targetEditor.OnInspectorGUI();
            EditorGUILayout.EndScrollView();
        }
    }
}