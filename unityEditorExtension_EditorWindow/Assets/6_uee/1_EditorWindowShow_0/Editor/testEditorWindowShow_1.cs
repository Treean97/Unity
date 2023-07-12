using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testEditorWindowShow_1 : EditorWindow
{
    [MenuItem("Window/Show testEditorWindowShow_1")]
    static void Open()
    {
        GetWindow<testEditorWindowShow_1>().Show();

    }
}
