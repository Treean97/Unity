using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testEditorWindowShow_6 : EditorWindow
{
    static testEditorWindowShow_6 mWindow;

    [MenuItem("Window/Show testEditorWindowShow_6")]
    static void Open()
    {
        if(mWindow == null)
        {
            mWindow = CreateInstance<testEditorWindowShow_6>();

            mWindow.position = new Rect(100f, 100f, 150f, 150f);
        }

        // focus가 사라지면, 자동으로 윈도우가 소멸된다
        mWindow.ShowAuxWindow();

    }


    private void OnGUI()
    {
        if(GUILayout.Button("TEST BUTTON"))
        {
            mWindow.Close();
        }

    }
}
