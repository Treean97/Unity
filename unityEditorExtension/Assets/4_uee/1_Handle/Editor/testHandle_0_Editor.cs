using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    Handle

    Scene View���� ���ӿ�����Ʈ�� ��� ���� �غ�� 3D GUI�̴�.
 
 */

// CustomEditor, Ÿ�� Ÿ���� �ѱ�(testHandle_0)
[CustomEditor(typeof(testHandle_0))]
public class testHandle_0_Editor : Editor
{
    // step_0
    //private void OnSceneGUI()
    //{
    //    // ���信�� �ƹ� �ڵ� ������ ������� �ʰڴٰ� ����
    //    Tools.current = Tool.None;
    //}

    // step_1
    private void OnSceneGUI()
    {
        Tools.current = Tool.None;

        var tComponent = target as testHandle_0;

        // ���� ������ �������� ������ �̵� �Ұ�
        // Handles.PositionHandle(tComponent.transform.position, tComponent.transform.rotation);

        // ���� ���� �޾����Ƿ� �̵� ����
        tComponent.transform.position = Handles.PositionHandle(tComponent.transform.position, tComponent.transform.rotation);

        // ȸ�� Ʋ �ڵ�
        tComponent.transform.rotation = Handles.RotationHandle(tComponent.transform.rotation, tComponent.transform.position);

        // ������ Ʋ �ڵ�
        tComponent.transform.localScale = Handles.ScaleHandle(tComponent.transform.localScale, tComponent.transform.position, tComponent.transform.rotation);
    }

}
