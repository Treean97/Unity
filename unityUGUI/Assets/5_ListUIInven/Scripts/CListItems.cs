using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CListItems : MonoBehaviour
{
    // prefab link
    [SerializeField]
    private CSlotItem PFSlotItem = null;


    // 임의의 N개의 슬롯들을 담아둘 가변 배열
    // 실행 중 배열의 크기 조정이 가능
    private List<CSlotItem> mListSlots = new List<CSlotItem>();


    // 자신을 포함한 게임 오브젝트
    CDxItemInventory mpDxItemInventory = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDxItemInventory(CDxItemInventory t)
    {
        mpDxItemInventory = t;
    }


    public void BuildUI()
    {
        // 가장 간단한 구현을 가정
        // clean
        foreach(var t in mListSlots)
        {
            // 슬롯들을 클리어
            Destroy(t.gameObject);
        }

        // 가변배열의 원소들을 클리어
        mListSlots.Clear();

        // build
        // 자료구조를 넘긴다
        BuildSlotWithDicItemInven(CGameDataMgr.GetInst().mDicItemInventory);
    }

    // 아이템들의 자료구조로 매개변수를 받아 UI를 구축
    void BuildSlotWithDicItemInven(SortedDictionary<string, List<CItemData>> tDic)
    {
        // 임의의 슬롯의 RectTransform
        RectTransform tSlotRectT = null;

        // 임의의 슬롯을 담을 지역변수
        CSlotItem tSlot = null;

        // 하나의 슬롯의 너비, 높이를 구해둠
        float tW = 1.0f;
        float tH = 1.0f;
        tW = ((RectTransform)(PFSlotItem.transform)).sizeDelta.x;
        tH = ((RectTransform)(PFSlotItem.transform)).sizeDelta.y;

        int ti = 0; // 순번을 지정할 인덱스

        // 필요한 slot UI 생성
        foreach(var t in tDic)
        {
            // 아이템이 있는지 검사
            if (t.Value.Count > 0)
            {
                tSlot = null;
                // 슬롯을 동적으로 생성
                // 위치 기준은 소유자 List
                tSlot = Instantiate<CSlotItem>(PFSlotItem, this.transform.position, Quaternion.identity);

                // 변환 계층 구조상 부모가 누구인지 설정한다
                tSlot.transform.SetParent(this.transform);

                // slot UI의 외관을 설정
                tSlotRectT = null;

                // UI구성요소 이므로 RectTransform으로 다뤄야 한다
                tSlotRectT = tSlotRectT.transform as RectTransform;

                // 위치 지정 Left, top을 시작점으로하여 y축 하방으로 달리도록 함
                tSlotRectT.anchoredPosition = new Vector2(0f, 0f - ti * tH);

                // 동적 생성된 슬롯의 너비, 높이 지정
                tSlotRectT.sizeDelta = new Vector2(tW, tH);

                // 크기는 각각의 축별로 1
                tSlot.transform.localScale = Vector3.one;

                // data를 설정
                // 같은 종류의 아이템이라면 모두 같다고 가정되어 있으므로 첫 번째 아이템의 정보를 얻어옴
                tSlot.SetItemData(t.Value[0]);
                // 가변배열의 원소의 갯수를 세어 아이템 개수를 얻는다
                tSlot.SetItemCount(t.Value.Count);

                // 소유자 설정
                tSlot.SetList(this);
                


                mListSlots.Add(tSlot);

                ti++;
            }
        }

        // instListItems의 높이 설정
        RectTransform tListRectT = null;

        tListRectT = this.transform as RectTransform;

        // 이 부분에서는 이미 ti에 슬롯 개수가 카운트 되어 있으므로
        // 아래와 같이 리스트의 높이를 구한다
        tListRectT.sizeDelta = new Vector2(tW, tH * ti);
        
        // 외관을 구성하는 작업이 모두 끝났으므로
        // slot UI들의 데이터 구성을 구축한다
        foreach(var t in mListSlots)
        {
            t.BuildUI();
        }

    }


    public void DoUseItem(CItemData tItemData)
    {
        mpDxItemInventory.DoUseItem(tItemData);
    }


}
