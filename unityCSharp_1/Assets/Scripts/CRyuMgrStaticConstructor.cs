using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Singleton Pattern 을 적용한 클래스
    두 번째 버전

    static constructor 정적 생성자와
    property를 이용


*/


public class CRyuMgrStaticConstructor
{
    public int mTestScore = 999;

    // mpInst에 static 적용 (힙에 high frequency heap 영역에 저장된 것)
    // 선언과 동시에 할당
    // 런타임 상수화
    private static readonly CRyuMgrStaticConstructor mpInst = new CRyuMgrStaticConstructor();

    // 객체는 이미 생성되어 있다
    // 여기서는 프로퍼티 문법을 통해 참조를 얻기만 한다
    public static CRyuMgrStaticConstructor GetInst
    {
        get
        {
            return mpInst;
        }
    }

    private CRyuMgrStaticConstructor()
    {
        Debug.Log("CRyuMgrStaticConstructor.CRyuMgrStaticConstructor");
    }
}
