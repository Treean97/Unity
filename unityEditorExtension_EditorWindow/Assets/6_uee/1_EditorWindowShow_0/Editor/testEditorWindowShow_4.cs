using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testEditorWindowShow_4 : EditorWindow
{
    static testEditorWindowShow_4 mWindow;

    [MenuItem("Window/Show testEditorWindowShow_4")]
    static void Open()
    {
        if(mWindow == null)
        {
            mWindow = CreateInstance<testEditorWindowShow_4>();

            mWindow.position = new Rect(100f, 100f, 150f, 150f);
        }

        mWindow.ShowPopup();

    }


    private void OnGUI()
    {
        if(GUILayout.Button("TEST BUTTON"))
        {
            mWindow.Close();
        }

    }
}
