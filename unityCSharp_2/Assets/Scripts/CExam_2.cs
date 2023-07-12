using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Stack<T>

    Queue<T>
    
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

    ���۸��� ������ �ִ� �ڷᱸ��
    ���� : LIFO

    ť : FIFO


*/

public class CExam_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Stack<int> tStack = new Stack<int>();

        tStack.Push(1);
        tStack.Push(777);
        tStack.Push(9);

        // ToArray : �迭�� ��ȯ
        int[] tInts = tStack.ToArray();

        Debug.Log("===ToArray===");
        foreach(var t in tInts)
        {
            Debug.Log(t.ToString());
        }
        Debug.Log("===//ToArray===");

        Debug.Log("===Stack===");
        while (tStack.Count > 0)
        {
            int t = tStack.Peek();
            Debug.Log(t.ToString());

            tStack.Pop();
        }
        Debug.Log("===//Stack===");

        // Queue
        Queue<int> tQueue = new Queue<int>();

        tQueue.Enqueue(1);
        tQueue.Enqueue(555);
        tQueue.Enqueue(22);

        
        Debug.Log("===Queue===");
        while (tQueue.Count > 0)
        {
            int t = tQueue.Peek();
            Debug.Log(t.ToString());

            tQueue.Dequeue();

        }
        Debug.Log("===//Queue===");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
