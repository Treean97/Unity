using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    private static CRyuMgr mpInst = null;

    // 아이템 도감 정보 (단 여기서는 간단하게 하기 위해 이미지에 대해서만 구축한다)
    // Sprite : UI와 Unity2D에서 사용가능하도록 유니티에서 분류하여 만들어놓은 Texture 종류
    public Sprite[] mSprites = null;

    // 인벤토리 정보(획득 아이템 목록 정보)
    public List<CItemInfo> mInventory = new List<CItemInfo>();

    
    public void CreateItemList()
    {
        // Resources 클래스는
        // 특수 폴더인 Resources 폴더와 함께 사용한다
        // 파일인 에셋을 스크립트 상에서 메모리로 로드하는 것이다
        mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }



    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }

    
    public static CRyuMgr GetInst()
    {
        if(mpInst == null)
        {
            mpInst = new CRyuMgr();
        }

        return mpInst;
    }

}

