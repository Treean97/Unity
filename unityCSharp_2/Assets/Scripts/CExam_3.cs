using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    
    Ʈ�� 1:n�� ���� �ڷᱸ��, ������ �ڷᱸ��
    ����Ʈ��
        1) Ʈ��
        2) �ִ� 2�������� �ڽ� ���
        3) lt, rt �ڽĳ��


    ����Ž��Ʈ��
        1) ����Ʈ��
        2) �ߺ��� ���� ������� ����
        3) lt Subtree�� ������ root�� ������ �۰� rt Subtree�� root�� ������ ũ��
        4) ����Ʈ���� ���� Ž��Ʈ��

    �ؽ� ���̺� : �����Ͱ� �� ��ġ�� �Ǵ� �ڷᱸ��

    Ű Key : �˻��� ������
    �� Value : ���� ������

    Dictionary
        �ؽ����̺��� �÷������� ������� ��
        �˻� �ӵ��� O(1)

        Ű�� �ߺ��� ������� �ʴ´�

        �ڷᱸ�� �̷л����� ���ĵ��� �ʴ� �ڷᱸ���̴�
        ������ C# Dictionary�� ������� ���ĵ� �����͸� ��� ǥ���� �����Ѵ�


    SortedDictionary
        ����Ž��Ʈ���� �÷������� ������� ��
        �˻��ӵ��� O(log n)

        Ű�� �ߺ��� ������� �ʴ´�
           
        ���� �߰� �� �ڵ����� ���ĵ� ���°� �ȴ�. �̰��� ����Ž��Ʈ���� Ư¡�̴�
        �׷��Ƿ� ������ȸ�ϸ� ���ĵ� ���·� ���´�

 */




public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("===Dictionary===");

        Dictionary<string, int> tDic = new Dictionary<string, int>();

        tDic.Add("One", 1);     // �����߰� �Լ�
        tDic.Add("Two", 2);

        tDic["Three"] = 3;      // �ش� �����ʹ� �ش� �÷��ǿ� �������� �����Ƿ� �߰�
        tDic["Three"] = 33;     // �ߺ��� ������� �����Ƿ�, ���ο� ������ ���� ����
        // �����迭 ǥ��� �߰� ����, ������ �ǵ����� ���� ������ �� �� �����Ƿ� ����

        foreach(var t in tDic)
        {
            Debug.Log($"key : {t.Key}, value : {t.Value.ToString()}");
        }

        Debug.Log(tDic["One"].ToString());
        // �ش� �����Ͱ� �÷��ǿ� �����ϴ� ��쿡, Ű�� �ε���ó�� ����Ͽ� �����迭 ǥ���ϸ� ���� ���´�
        // Ű�� ����� �˻� O(1)

        Debug.Log(tDic.ContainsKey("One").ToString());
        // Ű�� ����� �˻� O(1)

        Debug.Log(tDic.ContainsValue(1).ToString());
        // ���� ����� �˻� O(n)


        Debug.Log("===Sorted Dictionary");

        SortedDictionary<string, int> tSortedD = new SortedDictionary<string, int>();

        tSortedD.Add("a", 11);
        tSortedD.Add("c", 3333);
        tSortedD.Add("b", 222);
        

        // ������ȸ�Ͽ� �����ϱ� ������ ���ĵ� ���·� ���´�
        foreach (var t in tSortedD)
        {
            Debug.Log($"Key : {t.Key}, Value : {t.Value.ToString()}");

        }

        // �˻� �ð����⵵�� O(log n)
        Debug.Log(tSortedD["c"].ToString());

        // �˻� �ð����⵵�� O(log n)
        Debug.Log(tSortedD.ContainsKey("d").ToString());
        Debug.Log(tSortedD.ContainsKey("c").ToString());

        // �˻� �ð����⵵�� O(log n)
        tSortedD.Remove("a");

        Debug.Log("===Remove");
        foreach (var t in tSortedD)
        {
            Debug.Log($"Key : {t.Key}, Value : {t.Value.ToString()}");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
