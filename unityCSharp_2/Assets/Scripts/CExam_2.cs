using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Stack<T>

    Queue<T>
    
    자료구조 : 자료를 담는 구조물. 자료에 따라 모두 특성이 다르다

    배열 : 동일한 타입의 원소들의 '연속'적인 메모리 블럭
    링크드리스트 : '노드'가 '데이터'와 '링크'를 가지고, 각각의 링크에 의해 '선형'으로 '연결'되어 있는 자료구조
        

        단방향 링크드리스트 Single Linked List : 머리에서부터 접근
        양방향 링크드리스트 Double Linked List : 머리나 꼬리에서부터 접근
        (C#의 링크드리스트는 더블 링크드리스트로 만들어져 있다)

        장점
            1. 실행 중 자료를 추가, 삭제가 가능한 유연한 메모리 구조
            2. 자료를 추가, 삭제하는데 걸리는 시간이 일정하다 O(1)
        단점
            1. 임의 접근(Random Access) 불가
            2. 임의의 자료를 찾는데 시간이 오래 걸릴 수도 있다. 탐색은 O(n)

    동작명세가 정해져 있는 자료구조
    스택 : LIFO

    큐 : FIFO


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

        // ToArray : 배열로 변환
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
