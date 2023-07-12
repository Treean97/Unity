/*
    매개변수
    
        함수가 매개변수를 넘기는 방식

            값으로 전달(복사) pass by value

            ref 예약어 : pass by reference

            out 예약어 : pass by reference + 해당 함수의 정의를 나가기 전에 반드시 해당 변수는 값이 배정되어야 한다

            선택적 매개변수(매개변수 기본값 문법)
            
            param 예약어 : n개의 매개변수를 받는다
    
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class CExam_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tA = 3;
        int tB = 2;

        // before
        Debug.Log($"DoSwap {tA.ToString()}, {tB.ToString()}");

        // DoSwap(tA, tB);
        DoSwapRef(ref tA, ref tB);

        // after
        Debug.Log($"DoSwap {tA.ToString()}, {tB.ToString()}");

        Doit(ref tA, out tB);

        DoPrint(3, 2);

        int tResult = DoSum(3, 2, 0, 1, 2, 3);
        Debug.Log($"DoSum {tResult.ToString()}");

        tResult = DoSum(3, 2, new int[] { 0, 1, 2, 3 });
        Debug.Log($"DoSum {tResult.ToString()}");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoSwap(int tA, int tB)
    {
        int tTemp = 0;
        tTemp = tA;
        tA = tB;
        tB = tTemp;

    }

    void DoSwapRef(ref int tA, ref int tB)
    {
        int tTemp = 0;
        tTemp = tA;
        tA = tB;
        tB = tTemp;

    }

    void Doit(ref int tA, out int tB)
    {
        // out 예약어가 족용된 변수는 해당 함수의 정의를 나가기 전에 반드시 값이 배정되어야 한다
        tB = 0;


    }

    // 선택적 매개변수 : 매개변수를 선언할 때 초기화도 수행할 수 있다 <- 호출할 때 인자를 전달하지 않으면 초기에 지정된 값으로 호출된다
    // 이때 초기값은 컴파일 타임 상수여야만 한다
    // ref, out 예약어로 지정된 매개변수는 매개변수의 기본값을 지정 불가능하다
    void DoPrint(int tA, int tB, /*ref*/ int tVal = 777)
    {
        Debug.Log($"{tA.ToString()}, {tB.ToString()}, {tVal.ToString()}");
    }

    // params 예약어는 마지막 매개변수에만 지정 가능하다
    int DoSum(int tA, int tB, params int[] tIntArray)
    {
        int tResult = 0;

        tResult += tA;
        tResult += tB;

        for (int i = 0; i < tIntArray.Length; i++)
        {
            tResult += tIntArray[i];
        }


        return tResult;
    }

}
