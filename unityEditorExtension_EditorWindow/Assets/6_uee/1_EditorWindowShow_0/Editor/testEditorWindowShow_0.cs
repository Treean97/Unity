using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testEditorWindowShow_0 : EditorWindow
{
    [MenuItem("Window/Show testEditorWindowShow_0")]
    static void Open()
    {
        var t = CreateInstance<testEditorWindowShow_0>();

        t.Show();
    }
}
