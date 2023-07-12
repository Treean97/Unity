using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Singleton Pattern �� ������ Ŭ����
    �� ��° ����

    static constructor ���� �����ڿ�
    property�� �̿�


*/


public class CRyuMgrStaticConstructor
{
    public int mTestScore = 999;

    // mpInst�� static ���� (���� high frequency heap ������ ����� ��)
    // ����� ���ÿ� �Ҵ�
    // ��Ÿ�� ���ȭ
    private static readonly CRyuMgrStaticConstructor mpInst = new CRyuMgrStaticConstructor();

    // ��ü�� �̹� �����Ǿ� �ִ�
    // ���⼭�� ������Ƽ ������ ���� ������ ��⸸ �Ѵ�
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
