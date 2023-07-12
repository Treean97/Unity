using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Generic

    C#���� �Ϲ�ȭ ���α׷��� (General Programming)
    �� �����μ� �����Ǵ� �����̴�

    Ÿ���� �Ű�����ó�� �ٷ��(���� �ٸ� Ÿ�Ե鿡 ���� ���� ������ �ڵ带 �����)
    
    C++�� template�� ������ ������ �߷����� ���� Ÿ���� ����������,
    C#�� Generic�� ��������� �߷����� ���� Ÿ���� �����ȴ�

    ��, C++�� ������ ������ �ش� Ÿ�Ե鿡 ���� �Լ����� ���������,
    C#�� ������ �������� �� ��ü�� �����ϵȴ�


    C/C++���� �ۼ��� ���α׷��� ���� ���۱���    
        native code
        execute

    C#���� �ۼ��� ���α׷��� ���� ���۱���

        Compilation

        IL

        CLR
            JIT
            native code
            execute

 */

public class CExam_7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tA = 3;
        int tB = 2;
        DoSwap(ref tA, ref tB);

        Debug.Log($"after tA : {tA}, tB : {tB}");

        float tAA = 3.14f;
        float tBB = 1.2f;
        DoSwap(ref tAA, ref tBB);

        Debug.Log($"after tAA : {tAA}, tBB : {tBB}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generic Function
    // ������ ���� Ÿ���� �Ϲ�ȭ��Ű��, ��Ȳ�� ���� ��ü���� Ÿ���� �Լ����� ���������
    void DoSwap<T>(ref T tA, ref T tB)
    {
        T tTemp;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }
}
