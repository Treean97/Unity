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
        // ����Ƽ ������ �󿡼� ���������� �����Ͽ� �ۼ��� �ڵ�
        // Ȯ���� ǥ��
        mTestData = AssetDatabase.LoadAssetAtPath<ExamAsset_2>("Assets/Resources/ExamAsset_2.asset");
#else
        // ���Ӿ��� ������ �ڵ��̴�. �׷��� Resources Ŭ������ �̿��Ͽ� ������ �ε��Ͽ���
        // ���� �̸��� ǥ��
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
