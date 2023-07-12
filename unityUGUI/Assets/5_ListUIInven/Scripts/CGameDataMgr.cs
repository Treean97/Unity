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

public class CGameDataMgr
{
    private static CGameDataMgr mpInst = null;
    
    public Sprite[] mSprites = null;

    public List<CItemInfo> mInventory = new List<CItemInfo>();

    // 인벤토리 정보(획득 아이템 목록 정보)
    // 실제 아이템 데이터는 따로따로 저장할 것이고
    // UI에는 같은 종류의 아이템이면 한 슬롯만 할당하여 보여줄 것 (개수는 표시)
    public SortedDictionary<string, List<CItemData>> mDicItemInventory = new SortedDictionary<string, List<CItemData>>();
    
    public void CreateItemList()
    {
        // mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }

    public void AddItemToInven(CItemData tData)
    {
        // 참조타입의 객체이므로 새로 생성하여 값을 복사하도록 하겠다
        CItemData t = new CItemData();

        t = tData;

        Debug.Log($"AddItemToInven / id : {t.mId.ToString()}, name : {t.mName}");

        List<CItemData> tList = null;

        // mId를 키로 삼겠다
        string tKey = t.mId.ToString();

        
        if (mDicItemInventory.ContainsKey(tKey))
        {
            // 만약 이미 존재하는 아이템이라면 딕셔너리의 항목을 찾아 
            // 그 항목의 가변배열에 추가한다
            tList = mDicItemInventory[tKey];
            tList.Add(t);
        }
        else
        {
            // 만약 존재하지 않는 아이템이라면
            // 새롭게 항목을 구성한다
            tList = new List<CItemData>();
            tList.Add(t);

            mDicItemInventory.Add(tKey, tList);
        }

    }


    private CGameDataMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }

    
    public static CGameDataMgr GetInst()
    {
        if(mpInst == null)
        {
            mpInst = new CGameDataMgr();
        }

        return mpInst;
    }

}

