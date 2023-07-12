/*
    ����, �� �޸�

        ��������, �Ű������� ���ÿ� ����ȴ�
        
        ����Ÿ���� �ν��Ͻ�(�޸𸮿� ������ ������� ��ü)
        (�׷��Ƿ� ����Ÿ���� �ν��Ͻ��� '������ ������ ���� �������� �����Ҵ�� ��ü')
        �� �� �޸𸮿� ����ȴ�
        C#���� �����Ҵ�� �޸𸮴� ��������� ������ �� ����. ������ ����� ��ü(�޸� ����, ��۸� ������)�� �ڵ����� ���ŵȴ�(�ڵ����� �޸� ������ �ȴ�)
        

    Ȯ������
        
        �ݵ�� �ʱ�ȭ�ϴ� ��å

        ���������� ��� 
            ���������� ���� ��������(get) �� ���� �ݵ�� ������ ���� ����(set)�Ǿ�߸� �Ѵ�

        �޼ҵ�(�Լ�)�� ȣ���� ���� �ݵ�� �μ��� �����ؾ� �Ѵ�

        �� �ܿ� ��� ����(�������, �迭�� ����)�� ��Ÿ���� �ڵ����� ��� �ʱ�ȭ�Ѵ�
        ���� ����Ÿ���� ������� null�� �� ���� ���� 0���� �ʱ�ȭ�Ѵ�

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StringBuilder Ŭ������ ����ϱ� ����
using System.Text;
using Debug = UnityEngine.Debug;

class CTest
{
    public int mValue = 0;  // �� Ÿ��, ��� ����

}


public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // step_0
        int tResult = 0;    // �⺻Ÿ�Ե��� �� Ÿ������ ����Ѵ�
        tResult = DoFactorial(3);
        Debug.Log($"DoFactorial {tResult.ToString()}");

        int tA = 3;             // ��Ÿ��, �������� -> ����
        int tB = new int();     // ��Ÿ��, �������� -> ����
        tB = 2;

        tResult = tA + tB;
        Debug.Log($"tResult : {tResult.ToString()}");

        //step_1
        // Ŭ������ ����Ÿ������ ����Ѵ�
        StringBuilder tRef_0 = new StringBuilder("object_0");
        Debug.Log(tRef_0);


        StringBuilder tRef_1 = new StringBuilder("object_1");
        StringBuilder tRef_2 = tRef_1;
        Debug.Log(tRef_2);

        //step_2
        // CTest�� ����Ÿ��, �� Ÿ���� ��ü�� ���� �ִ�
        CTest tTest = new CTest();
        tTest.mValue = 777;     // mValue�� ���� �ִ�

        Debug.Log($"tTest.mValue : {tTest.mValue.ToString()}");



        // Ȯ������
        int[] tInts = new int[3];
        // �ʱ�ȭ�� ��������� ���� �ʾҴ�

        for(int i = 0; i < tInts.Length; i++)
        {
            Debug.Log($"tInts[{i}] : {tInts[i]}");

        }

        int tX;
        tX = 23;    // ���� ������ ����(set)����� ���(get) �����ϴ�
        Debug.Log(tX.ToString());



    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    int DoFactorial(int tN)
    {
        if(tN == 0)
        {
            return 1;
        }
        else
        {
            return tN * DoFactorial(tN - 1);
        }



    }
}
