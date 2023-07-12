using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(testHandle_1))]
public class testHandle_1_Editor : Editor
{
    private void OnSceneGUI()
    {
        Tools.current = Tool.None;

        var tComponent = target as testHandle_1;

        // step_0
        // Slider : 화살표를 방향으로 표시
        //Vector3 tPos = tComponent.transform.position + tComponent.transform.forward;
        //Handles.Slider(tPos, tComponent.transform.position);



        // step_1
        //Handles.color = Color.red;
        //Handles.color = Handles.zAxisColor;
        //Handles.Slider(tComponent.transform.position, tComponent.transform.forward);


        // step_2
        //Handles.color = Handles.zAxisColor;
        //tComponent.transform.position = Handles.Slider(tComponent.transform.position, tComponent.transform.forward);


        // step_3
        Handles.color = Color.black;
        Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 2f, Handles.CircleHandleCap, 1.0f);
        // Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 2f, Handles.ArrowHandleCap, 1.0f);
        // Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 2f, Handles.DotHandleCap, 1.0f);
        // Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 2f, Handles.ConeHandleCap, 1.0f);

    }

}
