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
        //// �������� �������� �׸��� 3D GUO�� �ڵ��� Ŀ�����ϰ� ���� �����ϴ�
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
