using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    LinkedList<T> ��ũ�帮��Ʈ
    
    �ڷᱸ�� : �ڷḦ ��� ������. �ڷῡ ���� ��� Ư���� �ٸ���

    �迭 : ������ Ÿ���� ���ҵ��� '����'���� �޸� ��
    ��ũ�帮��Ʈ : '���'�� '������'�� '��ũ'�� ������, ������ ��ũ�� ���� '����'���� '����'�Ǿ� �ִ� �ڷᱸ��
        

        �ܹ��� ��ũ�帮��Ʈ Single Linked List : �Ӹ��������� ����
        ����� ��ũ�帮��Ʈ Double Linked List : �Ӹ��� ������������ ����
        (C#�� ��ũ�帮��Ʈ�� ���� ��ũ�帮��Ʈ�� ������� �ִ�)

        ����
            1. ���� �� �ڷḦ �߰�, ������ ������ ������ �޸� ����
            2. �ڷḦ �߰�, �����ϴµ� �ɸ��� �ð��� �����ϴ� O(1)
        ����
            1. ���� ����(Random Access) �Ұ�
            2. ������ �ڷḦ ã�µ� �ð��� ���� �ɸ� ���� �ִ�. Ž���� O(n)



*/


public class CExam_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ��ũ�帮��Ʈ ��ü�� �ϳ� ����
        LinkedList<string> tNames = new LinkedList<string>();

        tNames.AddFirst("Aa");  // Head�ʿ� �߰�
        tNames.AddLast("Zz");   // Tail�ʿ� �߰�

        foreach(var t in tNames)
        {
            Debug.Log(t);
        }

        // ��ũ�� ����Ʈ�� ���������� ������� �ʴ´�
        // tNames[0] = "Hh";

        Debug.Log("After Add================");

        // Head������ �����Ͽ� �߰�
        tNames.AddAfter(tNames.First, "Bb");
        tNames.AddAfter(tNames.First.Next, "Cc");

        // Tail������ �����Ͽ� �߰�
        tNames.AddBefore(tNames.Last, "Yy");
        tNames.AddBefore(tNames.Last.Previous, "Xx");
                
        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        Debug.Log("After Remove=============");

        // Head������ �����Ͽ� ����
        tNames.RemoveFirst();

        // Tail������ �����Ͽ� ����
        tNames.RemoveLast();

        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        Debug.Log("Find====================");

        // �����˻� O(n)
        LinkedListNode<string> tNode = tNames.Find("Cc");

        if(tNode != null)
        {
            Debug.Log("Find Success Cc");
        }

        tNode = tNames.Find("Qq");

        if (tNode != null)
        {
            Debug.Log("Find Success Qq");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
