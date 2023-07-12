using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(testHandle_2))]
public class testHandle_2_Editor : Editor
{
    private void OnSceneGUI()
    {
        var tComponent = target as testHandle_2;

        //Handles.color = Color.red;
        //// 라인으로 폴리곤을 그린다 3D GUO인 핸들은 커스텀하게 제작 가능하다
        //Handles.DrawAAPolyLine(tComponent.mVertexs);

        // step_1
        Handles.color = Color.red;

        for(int ti = 0; ti < tComponent.mVertexs.Length; ti++)
        {
            tComponent.mVertexs[ti] = Handles.PositionHandle(tComponent.mVertexs[ti], Quaternion.identity);
        }

        Handles.DrawAAPolyLine(tComponent.mVertexs);

    }
}
