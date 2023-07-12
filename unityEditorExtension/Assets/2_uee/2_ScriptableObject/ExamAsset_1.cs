using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/*
    만드는 방법 : 

    ScriptableObect를 상속받은 클래스로 스크립트를 작성하고
    CreateInstance 함수를 이용하여 몌모리에 인스턴스 생성 후
    AssetDatabase의 CreateAsset함수를 이용항 ㅕ에셋으로 저장하고
    Refresh한다
 
 */


public class ExamAsset_1 : ScriptableObject
{
    public int mTest = 999;

#if UNITY_EDITOR
    [MenuItem("Example/Create ExamAsset_1")]
    static void CreateExamAsset_1()
    {
        // 메모리에 인스턴스를 하나 만든다
        var tEA_1 = CreateInstance<ExamAsset_1>();

        // 디스크에 에셋파일로 저장한다
        AssetDatabase.CreateAsset(tEA_1, "Assets/Resources/tExamAsset_1.asset");

        // 에셋 데이터베이스 갱신
        AssetDatabase.Refresh();
    }
#endif

}
