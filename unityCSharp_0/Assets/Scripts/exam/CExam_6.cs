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
        // C#에서 모든 참조타입의 궁극적인 부모클래스(기반 클래스)이다

        int tA = 777;           // 값타입의 변수 tA
        object tObjectA = tA;   // boxing   값타입 -> 참조타입
        // 힙메모리에 객체를 만들고 값을 복사하는 연산이 일어나므로 성능상 좋지 않다

        Debug.Log("boxing " + tObjectA);

        // unboxing     참조타입 -> 값타입
        int tB = (int)tObjectA;     // unboxing은 타입을 명시적으로 적어줘야만 한다. 성능상 좋지 않다
        Debug.Log("unboxing " + tB);


        //step_1
        object tD = 999;    // boxing 999는 상수고 int타입(값타입), tD는 object타입 (참조타입)
        long tLong_0 = (int)tD;     // unboxing, 값타입 끼리의 형변환은 암묵적

        //object tE = 777;
        //long tLong_1 = (long)tE;    // unboxing이 없으므로 실행중 에러

        object tF = 333;
        long tLong_2 = (long)(int)tF;   // unboxing, 값타입끼리의 형변환은 명시적

        //step_2
        int tFirst = 1;
        int tSecond = 1;
        // 다음의 문자열 생성에서도 boxing이 일어난다 int -> object 값 -> 참조
        Debug.Log($"A few Numbers : {tFirst}, {tSecond}");
        // 그러므로 문자열 생성에서는 boxing이 일어나지 않으므로 성능상 이점이다
        Debug.Log($"A few Numbers : {tFirst.ToString()}, {tSecond.ToString()}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
