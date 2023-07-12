using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testEditorWindowShow_3 : EditorWindow
{
    //static testEditorWindowShow_3 mWindow;

    [MenuItem("Window/Show testEditorWindowShow_3")]
    static void Open()
    {
        // SceneView가 있는 탭에 보여진다
        GetWindow<testEditorWindowShow_3>(typeof(SceneView));



    }
}
