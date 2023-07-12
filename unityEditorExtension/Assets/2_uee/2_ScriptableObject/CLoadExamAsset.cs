using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


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
