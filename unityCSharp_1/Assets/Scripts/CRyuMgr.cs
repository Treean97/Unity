using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    싱글톤 패턴 적용
    싱글톤 : 객체의 최대 생성 개수를 1개로 제한하는 것이 목적인 패턴
    
    1) mpInstance를 static을 적용한다
    2) 생성자는 private
    3) GetInstance 함수안에는 객체를 1개로 생성 제한하는 판단 구문이 존재한다

    C#에서 객체의 생성 단계
    
    임의의 타입으로 '첫 번째 인스턴스'를 생성할 시 수행되는 과정
    
    정적 변수 단계
        1. 정적 변수의 저장공간(메모리)를 0으로 초기화
        2. 정적 변수에 대한 초기화 구문을 수행
        3. 정적 생성자 수행
            만약 상속관계라면
            가. 베이스 클래스(부모클래스)의 정적 생성자 수행
            나. 자신의 정적 생성자 수행
 
    ===========================================

    인스턴스 변수 단계
        1. 인스턴스 변수의 저장공간(메모리)를 0으로 초기화
        2. 인스턴스 변수에 대한 초기화 구문을 수행
        3. 인스턴스 생성자 수행
            만약 상속관계라면
            가. 베이스 클래스(부모클래스)의 인스턴스 생성자 수행
            나. 자신의 인스턴스 생성자 수행
 */

public class CRyuMgr
{
    // mpInst에 static을 적용한다
    private static CRyuMgr mInst = null;   // C#에서는 static 참조 변수의 선언 시 null로 초기화 표현이 가능하다
    // C#에서 static이 적용된 변수는 힙(의 특별한 위치 High Frequency Heap)에 위치한다

    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }

    // 1개만 인스턴스화 한다
    public static CRyuMgr GetInst()
    {
        if(mInst == null)
        {
            mInst = new CRyuMgr();
        }

        return mInst;
    }

}

