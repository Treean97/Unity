using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    
    트리 1:n의 비선형 자료구조, 계층형 자료구조
    이진트리
        1) 트리
        2) 최대 2개까지의 자식 노드
        3) lt, rt 자식노드


    이진탐색트리
        1) 이진트리
        2) 중복된 값을 허용하지 않음
        3) lt Subtree의 값들은 root의 값보다 작고 rt Subtree는 root의 값보다 크다
        4) 서브트리도 이진 탐색트리

    해쉬 테이블 : 데이터가 곧 위치가 되는 자료구조

    키 Key : 검색용 데이터
    값 Value : 실제 데이터

    Dictionary
        해쉬테이블이 컬렉션으로 만들어진 것
        검색 속도가 O(1)

        키는 중복을 허용하지 않는다

        자료구조 이론상으로 정렬되지 않는 자료구조이다
        하지만 C# Dictionary를 대상으로 정렬된 데이터를 얻는 표현이 존재한다


    SortedDictionary
        이진탐색트리가 컬렉션으로 만들어진 것
        검색속도가 O(log n)

        키는 중복을 허용하지 않는다
           
        원소 추가 시 자동으로 정렬된 상태가 된다. 이것은 이진탐색트리의 특징이다
        그러므로 중위순회하면 정렬된 형태로 나온다

 */




public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("===Dictionary===");

        Dictionary<string, int> tDic = new Dictionary<string, int>();

        tDic.Add("One", 1);     // 원소추가 함수
        tDic.Add("Two", 2);

        tDic["Three"] = 3;      // 해당 데이터는 해당 컬렉션에 존재하지 않으므로 추가
        tDic["Three"] = 33;     // 중복을 허용하지 않으므로, 새로운 값으로 덮어 씌움
        // 연관배열 표기로 추가 가능, 하지만 의도하지 않은 동작이 될 수 있으므로 주의

        foreach(var t in tDic)
        {
            Debug.Log($"key : {t.Key}, value : {t.Value.ToString()}");
        }

        Debug.Log(tDic["One"].ToString());
        // 해당 데이터가 컬렉션에 존재하는 경우에, 키를 인덱스처럼 사용하여 연관배열 표기하면 값이 나온다
        // 키를 사용한 검색 O(1)

        Debug.Log(tDic.ContainsKey("One").ToString());
        // 키를 사용한 검색 O(1)

        Debug.Log(tDic.ContainsValue(1).ToString());
        // 값을 사용한 검색 O(n)


        Debug.Log("===Sorted Dictionary");

        SortedDictionary<string, int> tSortedD = new SortedDictionary<string, int>();

        tSortedD.Add("a", 11);
        tSortedD.Add("c", 3333);
        tSortedD.Add("b", 222);
        

        // 중위순회하여 열거하기 때문에 정렬된 형태로 나온다
        foreach (var t in tSortedD)
        {
            Debug.Log($"Key : {t.Key}, Value : {t.Value.ToString()}");

        }

        // 검색 시간복잡도는 O(log n)
        Debug.Log(tSortedD["c"].ToString());

        // 검색 시간복잡도는 O(log n)
        Debug.Log(tSortedD.ContainsKey("d").ToString());
        Debug.Log(tSortedD.ContainsKey("c").ToString());

        // 검색 시간복잡도는 O(log n)
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
