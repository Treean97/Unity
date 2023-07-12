/*
    ����ȯ 

    C#������ ����ȯ�� �����ϴ� ����� ũ�� �ΰ��� �ִ�.

    1. �����Ϸ��� Ÿ��ĳ��Ʈ(����ȯ) ������ ���� <- �츮�� �˰� �ִ� ����ȯ ������

    2.  
        as ������
        �⺻Ÿ���� �ȵ�(nullable(null ���� ���� �� �ִ� Ÿ��)�� Ÿ�Կ� �����ϴ�)
        <- ������ ��ü�� ������ ����
        
        is ������ : ����ȯ�� �������� �˻��ϴ� �������̴�
            <- �� �ƴϸ� ���� ����

        as �����ڸ� ����� �� �ִ� �����
        as �����ڸ� ����ϴ� ���� Ÿ��ĳ��Ʈ �����ڸ� ����ϴ� ��캸�� �����ϴ�

 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CUnitRyu
{

}

class CActorRyu : CUnitRyu
{

}

class CBraveRyu : CActorRyu
{

}

/*
    �θ� Ŭ���������� Ÿ������ �ڽ� Ŭ���� Ÿ���� ��ü�� ����Ų��.
    CUnit* tpUnit = &tActor;    // ����
 
    �ڽ� Ŭ���������� Ÿ������ �θ� Ŭ���� Ÿ���� ��ü�� ����Ų��    
    CActor* tpActor = &tUnit;   // �Ұ���

 */

public class CExam_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        int tA = 3;
        float tB = 3.14f;

        // �����Ϸ����� �����ϴ� Ÿ��ĳ��Ʈ ����
        tA = (int)tB;

        // �⺻Ÿ�Կ� as ������ �ȵ�
        // tA = tB as int;


        // step_1, step_2
        // �θ�Ŭ���� Ÿ���� ������ �ڽ� Ŭ����Ÿ���� ��ü�� �⸮Ų��. �̷��� ��츸 ����ȯ�� �����Ѵ�
        // step_2 ���� step_1�� �� �����ϴ�


        // step_1
        CUnitRyu tUnit = new CUnitRyu();
        CActorRyu tActor = new CActorRyu();
        CBraveRyu tBrave = new CBraveRyu();

        // ����ȯ ����
        // '��Ÿ��'�� ��ü�� Ÿ���� ��ȯ�Ϸ��� Ÿ�԰� ��ġ�ϴ� ��쿡�� ����ȯ�� �����Ѵ�
        // '���� ��'�� ����ȯ�� �����ϰ� �������� ���ο� ���� ��ȿ�� ������ �����Ѵ�
        CUnitRyu u = tActor as CUnitRyu;
        if(u != null)
        {
            Debug.Log("OK, actor as unit");
        }
        
        // ����ȯ ����
        CBraveRyu v = tActor as CBraveRyu;
        if (v != null)
        {
            Debug.Log("OK, actor as brave");
        }

        // step_1.5
        // is �����ڴ� ��, ������ ����
        bool tIsU = tActor is CUnitRyu;
        if (tIsU)
        {
            Debug.Log("OK, actor as unit");
        }

        // ����ȯ ����
        bool tIsV = tActor is CBraveRyu;
        if (tIsV)
        {
            Debug.Log("OK, actor as brave");
        }



        // step_2
        // '������' ��ӿ� ����ȯ�� ������ ������ �����Ǿ� �ִ�
        // �׷��Ƿ� ������ ����ȯ�� �����Ϸ��� �Ѵ�
        // ������ ���������� ��Ÿ�ӿ� ��� ���� ���� �� �� ����

        try        // ���� ó�� ����
        {
            // ���⿡ ������ ������ �ΰ�, ���� �ش� �������� �������� ��Ȳ(���� �� ����)�� �߻��ϸ�
            // catch �������� �����ϰ� ������ �帧�� �̵��Ͽ� ���� ��Ȳ�� ó���� �� �ְ� �ϴ� �����̴�
            CUnitRyu uu = (CUnitRyu)tActor;
        }
        catch(InvalidCastException)
        {
            Debug.Log("Not Ok, actor as Not unit");
        }

        try
        {
            CBraveRyu vv = (CBraveRyu)tActor;
        }
        catch
        {
            Debug.Log("Not Ok, actor as Not brave");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
