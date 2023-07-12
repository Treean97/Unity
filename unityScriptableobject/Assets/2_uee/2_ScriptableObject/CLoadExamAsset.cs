using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    scriptableObject를 이용하면
    나만의 사용자 정의 에셋을 만들 수 있다

    이를테면
    이전에 xml, json등으로 파일 포팻을 작성하여
    Data Driven개념을 적용하는 예시를 보였었는데

    여기에 쓰인 ScriptaleObject로 xml, json ... 등을 대체하여 사용이 가능하다

    또한 ScriptableObject를 사용하면
    유니티 에디터 상에서 매우 손쉽게 스크립트를 이용하여 에셋 데이터 파일을 작성가능하다

    xml, json 등은 텍스트 형식이다.
    ScriptableObject를 상속받은 스크립트를 사용하여 만든 사용자 정의 에셋은 바이너리 형식이다
    바이너리 형식의 데이터 이점이 있다
 */ 

public class CLoadExamAsset : MonoBehaviour
{
    ExamAsset_2 mTestData = null;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        // 유니티 에디터 상에서 에셋파일을 가정하여 작성한 코드
        // 확장자 표기
        mTestData = AssetDatabase.LoadAssetAtPath<ExamAsset_2>("Assets/Resources/ExamAsset_2.asset");
#else
        // 게임앱을 가정한 코드이다. 그래서 Resources 클래스를 이용하여 에셋을 로드하였다
        // 에셋 이름만 표기
        mTestData = Resources.Load<ExamAsset_2>("ExamAsset_2");
#endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
#if UNITY_EDITOR
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"Editor : mTestData.mF : {mTestData.mF.ToString()}");
        GUI.Label(new Rect(0f, 50f, 300f, 50f), $"Editor : mTestData.GetNumber : {mTestData.GetNumber().ToString()}");
#else
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"In Game : mTestData.mF : {mTestData.mF.ToString()}");
        GUI.Label(new Rect(0f, 50f, 300f, 50f), $"In Game : mTestData.GetNumber : {mTestData.GetNumber().ToString()}");
#endif

    }
}
