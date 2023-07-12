using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(testHandle2DGUI))]
public class testHandle2DGUI_editor : Editor
{
    // step_0
    //private void OnSceneGUI()
    //{
    //    Handles.BeginGUI();

    //    GUILayout.Button("Test Button", GUILayout.Width(100f));

    //    Handles.EndGUI();

    //}

    int mWinId = 123456;
    Rect mRect;
    bool mIsToggle = false;

    // step_1
    //private void OnSceneGUI()
    //{
    //    Handles.BeginGUI();

    //    mRect = GUILayout.Window(mWinId, mRect, (id) =>
    //    {
    //        EditorGUILayout.LabelField("label test");
    //        mIsToggle = EditorGUILayout.ToggleLeft("Toggle", mIsToggle);

    //        GUILayout.Button("Test Button", GUILayout.Width(100f));

    //        GUI.DragWindow();

    //    }, "Window", GUILayout.Width(100f));



    //    Handles.EndGUI();

    //}

    private void OnSceneGUI()
    {
        var t = target as testHandle2DGUI;

        Handles.BeginGUI();

        EditorGUILayout.LabelField(t.mString, EditorStyles.helpBox, GUILayout.Width(300));

        Handles.EndGUI();
    }

}
