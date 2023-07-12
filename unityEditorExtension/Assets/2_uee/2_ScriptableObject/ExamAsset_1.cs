using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/*
    ����� ��� : 

    ScriptableObect�� ��ӹ��� Ŭ������ ��ũ��Ʈ�� �ۼ��ϰ�
    CreateInstance �Լ��� �̿��Ͽ� ��𸮿� �ν��Ͻ� ���� ��
    AssetDatabase�� CreateAsset�Լ��� �̿��� �ſ������� �����ϰ�
    Refresh�Ѵ�
 
 */


public class ExamAsset_1 : ScriptableObject
{
    public int mTest = 999;

#if UNITY_EDITOR
    [MenuItem("Example/Create ExamAsset_1")]
    static void CreateExamAsset_1()
    {
        // �޸𸮿� �ν��Ͻ��� �ϳ� �����
        var tEA_1 = CreateInstance<ExamAsset_1>();

        // ��ũ�� �������Ϸ� �����Ѵ�
        AssetDatabase.CreateAsset(tEA_1, "Assets/Resources/tExamAsset_1.asset");

        // ���� �����ͺ��̽� ����
        AssetDatabase.Refresh();
    }
#endif

}
