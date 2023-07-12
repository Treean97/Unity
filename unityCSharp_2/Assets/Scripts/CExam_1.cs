using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    LinkedList<T> 링크드리스트
    
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



*/


public class CExam_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 링크드리스트 객체를 하나 만듦
        LinkedList<string> tNames = new LinkedList<string>();

        tNames.AddFirst("Aa");  // Head쪽에 추가
        tNames.AddLast("Zz");   // Tail쪽에 추가

        foreach(var t in tNames)
        {
            Debug.Log(t);
        }

        // 링크드 리스트는 임의접근을 허용하지 않는다
        // tNames[0] = "Hh";

        Debug.Log("After Add================");

        // Head쪽으로 접근하여 추가
        tNames.AddAfter(tNames.First, "Bb");
        tNames.AddAfter(tNames.First.Next, "Cc");

        // Tail쪽으로 접근하여 추가
        tNames.AddBefore(tNames.Last, "Yy");
        tNames.AddBefore(tNames.Last.Previous, "Xx");
                
        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        Debug.Log("After Remove=============");

        // Head쪽으로 접근하여 삭제
        tNames.RemoveFirst();

        // Tail쪽으로 접근하여 삭제
        tNames.RemoveLast();

        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        Debug.Log("Find====================");

        // 순차검색 O(n)
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
