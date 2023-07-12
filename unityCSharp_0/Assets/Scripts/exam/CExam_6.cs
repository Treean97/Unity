using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // step_0
        // object
        // C#���� ��� ����Ÿ���� �ñ����� �θ�Ŭ����(��� Ŭ����)�̴�

        int tA = 777;           // ��Ÿ���� ���� tA
        object tObjectA = tA;   // boxing   ��Ÿ�� -> ����Ÿ��
        // ���޸𸮿� ��ü�� ����� ���� �����ϴ� ������ �Ͼ�Ƿ� ���ɻ� ���� �ʴ�

        Debug.Log("boxing " + tObjectA);

        // unboxing     ����Ÿ�� -> ��Ÿ��
        int tB = (int)tObjectA;     // unboxing�� Ÿ���� ��������� ������߸� �Ѵ�. ���ɻ� ���� �ʴ�
        Debug.Log("unboxing " + tB);


        //step_1
        object tD = 999;    // boxing 999�� ����� intŸ��(��Ÿ��), tD�� objectŸ�� (����Ÿ��)
        long tLong_0 = (int)tD;     // unboxing, ��Ÿ�� ������ ����ȯ�� �Ϲ���

        //object tE = 777;
        //long tLong_1 = (long)tE;    // unboxing�� �����Ƿ� ������ ����

        object tF = 333;
        long tLong_2 = (long)(int)tF;   // unboxing, ��Ÿ�Գ����� ����ȯ�� �����

        //step_2
        int tFirst = 1;
        int tSecond = 1;
        // ������ ���ڿ� ���������� boxing�� �Ͼ�� int -> object �� -> ����
        Debug.Log($"A few Numbers : {tFirst}, {tSecond}");
        // �׷��Ƿ� ���ڿ� ���������� boxing�� �Ͼ�� �����Ƿ� ���ɻ� �����̴�
        Debug.Log($"A few Numbers : {tFirst.ToString()}, {tSecond.ToString()}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
