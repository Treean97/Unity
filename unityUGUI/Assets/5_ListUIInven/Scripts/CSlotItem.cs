using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CSlotItem : MonoBehaviour
{
    // 본질적인 아이템 데이터 Document
    private CItemData mItemData = null;

    // 눈에 보이는 UI 구성요소 View
    // [SerializeField] 속성은 유니티에서 제공하고
    // public이 아니지만 직렬화를 적용하여 유니티 에디터 상에 노출시키는 역할을 한다
    [SerializeField]
    private Image mImgItem = null;

    [SerializeField]
    private TMP_Text mTxtName = null;

    [SerializeField]
    private TMP_Text mTxtDesc = null;

    [SerializeField]
    private Button mBtnUse = null;


    // 자신이 속한 소유자 List UI
    CListItems mList = null;

    // 아이템의 갯수
    int mItemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BuildUI()
    {
        //clean


        //build
        if (mImgItem != null)
        {
            string t = $"{mItemData.mName} x {mItemCount.ToString()}";
            mTxtName.text = t;
            mTxtDesc.text = mItemData.mDesc;

            // mImgItem.sprite = 
        }

    }

    // 자신이 속한 소유자를 지정한다
    public void SetList(CListItems tList)
    {
        mList = tList;
    }


    public CItemData GetItemData()
    {
        return mItemData;

    }

    // 아이템의 정보 설정
    public void SetItemData(CItemData t)
    {
        mItemData = t;

    }

    // 아이템의 개수 설정
    public void SetItemCount(int tCount)
    {
        mItemCount = tCount;
    }

    // 버튼 클릭 시 행할 동작 이벤트 핸들러
    public void OnClickBtnUse()
    {
        // 해당 아이템 정보를 넘겨 처리를 위임한다
        mList.DoUseItem(mItemData);
    }

}
