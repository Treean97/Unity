/*
    스택, 힙 메모리

        지역변수, 매개변수는 스택에 적재된다
        
        참조타입의 인스턴스(메모리에 실제로 만들어진 객체)
        (그러므로 참조타입의 인스턴스란 '포인터 변수에 의해 가리켜진 동적할당된 객체')
        는 힙 메모리에 적재된다
        C#에서 동적할당된 메모리는 명시적으로 해지할 수 없다. 참조가 사라진 객체(메모리 누수, 댕글링 포인터)는 자동으로 수거된다(자동으로 메모리 관리가 된다)
        

    확정배정
        
        반드시 초기화하는 정책

        지역변수의 경우 
            지역변수의 값을 읽으려면(get) 그 전에 반드시 임의의 값이 배정(set)되어야만 한다

        메소드(함수)를 호출할 때는 반드시 인수를 지정해야 한다

        그 외에 모든 변수(멤버변수, 배열의 원소)는 런타임이 자동으로 모두 초기화한다
        만약 참조타입의 변수라면 null로 그 외의 경우는 0으로 초기화한다

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StringBuilder 클래스를 사용하기 위해
using System.Text;
using Debug = UnityEngine.Debug;

class CTest
{
    public int mValue = 0;  // 값 타입, 멤버 변수

}


public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // step_0
        int tResult = 0;    // 기본타입들은 값 타입으로 취급한다
        tResult = DoFactorial(3);
        Debug.Log($"DoFactorial {tResult.ToString()}");

        int tA = 3;             // 값타입, 지역변수 -> 스택
        int tB = new int();     // 값타입, 지역변수 -> 스택
        tB = 2;

        tResult = tA + tB;
        Debug.Log($"tResult : {tResult.ToString()}");

        //step_1
        // 클래스는 참조타입으로 취급한다
        StringBuilder tRef_0 = new StringBuilder("object_0");
        Debug.Log(tRef_0);


        StringBuilder tRef_1 = new StringBuilder("object_1");
        StringBuilder tRef_2 = tRef_1;
        Debug.Log(tRef_2);

        //step_2
        // CTest는 참조타입, 이 타입의 객체는 힙에 있다
        CTest tTest = new CTest();
        tTest.mValue = 777;     // mValue는 힙에 있다

        Debug.Log($"tTest.mValue : {tTest.mValue.ToString()}");



        // 확정배정
        int[] tInts = new int[3];
        // 초기화를 명시적으로 하지 않았다

        for(int i = 0; i < tInts.Length; i++)
        {
            Debug.Log($"tInts[{i}] : {tInts[i]}");

        }

        int tX;
        tX = 23;    // 지역 변수는 설정(set)해줘야 사용(get) 가능하다
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
