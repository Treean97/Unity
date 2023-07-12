using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class testEditorWindowPopup : EditorWindow
{
    [MenuItem("Window/Show testDeitorWindowPopup")]
    static void Open()
    {
        GetWindow<testEditorWindowPopup>(typeof(SceneView));
    }

    // UI의 외관만들기
    private void OnGUI()
    {
        EditorGUILayout.LabelField("This is Popup Window", EditorStyles.boldLabel);

        if(GUILayout.Button("Popup Content", GUILayout.Width(150f)))
        {
            // PopupWindow.Show(,);
        }

    }

}
