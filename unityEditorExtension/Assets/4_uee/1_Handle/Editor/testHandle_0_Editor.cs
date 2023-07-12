using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    Handle

    Scene View에서 게임오브젝트의 제어를 위해 준비된 3D GUI이다.
 
 */

// CustomEditor, 타겟 타입을 넘김(testHandle_0)
[CustomEditor(typeof(testHandle_0))]
public class testHandle_0_Editor : Editor
{
    // step_0
    //private void OnSceneGUI()
    //{
    //    // 씬뷰에서 아무 핸들 도구도 사용하지 않겠다고 설정
    //    Tools.current = Tool.None;
    //}

    // step_1
    private void OnSceneGUI()
    {
        Tools.current = Tool.None;

        var tComponent = target as testHandle_0;

        // 리턴 값으로 갱신하지 않으면 이동 불가
        // Handles.PositionHandle(tComponent.transform.position, tComponent.transform.rotation);

        // 리턴 값을 받았으므로 이동 가능
        tComponent.transform.position = Handles.PositionHandle(tComponent.transform.position, tComponent.transform.rotation);

        // 회전 틀 핸들
        tComponent.transform.rotation = Handles.RotationHandle(tComponent.transform.rotation, tComponent.transform.position);

        // 스케일 틀 핸들
        tComponent.transform.localScale = Handles.ScaleHandle(tComponent.transform.localScale, tComponent.transform.position, tComponent.transform.rotation);
    }

}
