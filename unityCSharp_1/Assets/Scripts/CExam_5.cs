/*
    형변환 

    C#에서는 형변환을 수행하는 방법이 크게 두가지 있다.

    1. 컴파일러의 타입캐스트(형변환) 연산자 구문 <- 우리가 알고 있는 형변환 연산자

    2.  
        as 연산자
        기본타입은 안됨(nullable(null 값을 가질 수 있는 타입)한 타입에 가능하다)
        <- 임의의 객체의 참조를 리턴
        
        is 연산자 : 형변환이 가능한지 검사하는 연산자이다
            <- 참 아니면 거짓 리턴

        as 연산자를 사용할 수 있는 경우라면
        as 연산자를 사용하는 것이 타입캐스트 연산자를 사용하는 경우보다 안전하다

 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CUnitRyu
{

}

class CActorRyu : CUnitRyu
{

}

class CBraveRyu : CActorRyu
{

}

/*
    부모 클래스포인터 타입으로 자식 클래스 타입의 객체를 가리킨다.
    CUnit* tpUnit = &tActor;    // 가능
 
    자식 클래스포인터 타입으로 부모 클래스 타입의 객체를 가리킨다    
    CActor* tpActor = &tUnit;   // 불가능

 */

public class CExam_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        int tA = 3;
        float tB = 3.14f;

        // 컴파일러에서 지원하는 타입캐스트 적용
        tA = (int)tB;

        // 기본타입에 as 적용은 안됨
        // tA = tB as int;


        // step_1, step_2
        // 부모클래스 타입의 참조로 자식 클래스타입의 객체를 기리킨다. 이러한 경우만 형변환이 성공한다
        // step_2 보다 step_1이 더 안전하다


        // step_1
        CUnitRyu tUnit = new CUnitRyu();
        CActorRyu tActor = new CActorRyu();
        CBraveRyu tBrave = new CBraveRyu();

        // 형변환 성공
        // '런타임'에 객체의 타입이 변환하려는 타입과 일치하는 경우에만 형변환이 성공한다
        // '실행 중'에 형변환을 수행하고 가능한지 여부에 따라 유효한 참조를 리턴한다
        CUnitRyu u = tActor as CUnitRyu;
        if(u != null)
        {
            Debug.Log("OK, actor as unit");
        }
        
        // 형변환 실패
        CBraveRyu v = tActor as CBraveRyu;
        if (v != null)
        {
            Debug.Log("OK, actor as brave");
        }

        // step_1.5
        // is 연산자는 참, 거짓을 리턴
        bool tIsU = tActor is CUnitRyu;
        if (tIsU)
        {
            Debug.Log("OK, actor as unit");
        }

        // 형변환 실패
        bool tIsV = tActor is CBraveRyu;
        if (tIsV)
        {
            Debug.Log("OK, actor as brave");
        }



        // step_2
        // '컴파일' 싲머에 형변환을 수행할 것임이 결정되어 있다
        // 그러므로 강제로 형변환을 수행하려고 한다
        // 컴파일 시점에서는 런타임에 어떠한 값이 올지 알 수 없다

        try        // 예외 처리 구문
        {
            // 여기에 임의의 구문을 두고, 만약 해당 구문에서 예외적인 상황(실행 중 에러)이 발생하면
            // catch 구문으로 안전하게 실행의 흐름이 이동하여 예외 상황을 처리할 수 있게 하는 문법이다
            CUnitRyu uu = (CUnitRyu)tActor;
        }
        catch(InvalidCastException)
        {
            Debug.Log("Not Ok, actor as Not unit");
        }

        try
        {
            CBraveRyu vv = (CBraveRyu)tActor;
        }
        catch
        {
            Debug.Log("Not Ok, actor as Not brave");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
