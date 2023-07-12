using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    유니티 에디터 확장 기능 중에는
    인스펙터에 표시되는
    컴포넌트의 외관을 변경시켜주는 기능을 제공한다

    그 중에 하나가 CustomEditor이다

    이것은 컴포넌트 단위로 적용된다
 */

[CustomEditor(typeof(CUnit))] // CustomEditor속성, 타겟 타입을 알려준다
public class CUnitInspector : Editor    // 상속
{
    // 타겟 타입에 대한 변수를 하나 선언
    CUnit mpUnit = null;    

    private void OnEnable()
    {
        // 타겟을 얻는다
        mpUnit = this.target as CUnit;  
    }

    // 인스펙터에 표시되는 컴포넌트의 외관은 이 이벤트 함수를 커스터마이징한다
    public override void OnInspectorGUI()   
    {
        // 직렬화 기능을 갱신
        serializedObject.Update();

        // 부모클래스Editor의 OnInspectorGUI를 호출
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("AP", mpUnit.mAP.ToString());

        if(GUILayout.Button("Random mEndurance"))
        {
            mpUnit.mEndurance = Random.Range(0, 99);
        }

        if (GUILayout.Button("Random mStr"))
        {
            mpUnit.mStr = Random.Range(0, 9);
        }


        // 직렬화 기능을 이용하여 변경된 외관을 적용
        serializedObject.ApplyModifiedProperties();
        
    }

    // 프리뷰 표시를 위해 준비된 이벤트 함수
    public override bool HasPreviewGUI()
    {
        // return base.HasPreviewGUI();
        // true : 프리뷰 표시 있음
        return true;
    }

    public override GUIContent GetPreviewTitle()
    {
        // return base.GetPreviewTitle();
        return new GUIContent("unit stats");
    }


    public override void OnPreviewSettings()
    {
        base.OnPreviewSettings();

        // UI의 스타일 만듦
        //GUIStyle tPreLabel = new GUIStyle("preview label");
        //GUIStyle tPreButton = new GUIStyle("preview button");

        // UI만듦
        GUILayout.Label("Label test", GUIStyle.none);
        GUILayout.Button("Button test", GUIStyle.none);
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);

        GUI.Box(r, "AP결정수식 :\nmBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16)");
    }

}

