using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/*
    string vs StringBuilder

 
 */


public class cs_string_vs_StringBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // step_0
        // �� �ڵ�� ���� �ڵ尡 �ƴϴ�
        // �� �ڵ�� ��ġ ���ڿ��� �߰��ϴ� ��ó�� ��������
        // �߰��ϴ� ���� �ƴϴ� 
        // string�� ����Ұ����� ���ڿ��� �ٷ�� ���·� �����Ѵ�. (c�� �����ڸ� const char*)
        // �� �̹� �ִ� ���ڿ��� ����(������ �÷���)����� �ǰ� ,���ο� ���ڿ��� ������� ��ü �Ǵ� ���̴�

        int tAge = 21;
        string tMsg_0 = "I am ";
        tMsg_0 += "a good ";
        tMsg_0 += "boy. ";
        tMsg_0 += "This is ";
        tMsg_0 += tAge.ToString();

        Debug.Log(tMsg_0);

        // step_1
        // �׷��� step_0�� ǥ�����ٴ� �Ʒ��� ���� ǥ���ϴ� ���� �� ����
        string tMsg_1 = string.Format("I am a good boy. This is {0}", tAge);
        // c�� ġ�� printf
        Debug.Log(tMsg_1);

        string tMsg_1_0 = $"I am a good boy. This is {tAge.ToString()}";
        Debug.Log(tMsg_1_0);


        // step_2
        // �ƿ� step_0�� ���� ��츦 ���� ������� Ŭ������ �ٷ� StringBuilder�̴�
        // ���� ������ ���ڿ� Ÿ���̴�
        // ���������δ� ���� �Ұ����� ���ڿ� string�� ����� ����
        StringBuilder tMsg_2 = new StringBuilder("I am ");
        tMsg_2.Append("a good ");
        tMsg_2.Append("boy. ");
        tMsg_2.Append("This is ");
        tMsg_2.Append(tAge.ToString());

        Debug.Log(tMsg_2.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
