using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager;

public class CUIInvenOneSlot : MonoBehaviour
{
    public Image mImgItem = null;
    public TMP_Text mTxtName = null;

    public void BuildUI()
    {
        // clean
        mImgItem.sprite = null;
        mTxtName.text = "";

        CItemInfo tInfo = null;
        // build
        if (CRyuMgr.GetInst().mInventory.Count > 0)
        {
            // 아이템이 하나밖에 없으므로 이렇게 가정
            tInfo = CRyuMgr.GetInst().mInventory[0];
        }
        
        if(tInfo != null)
        {
            // Document의 내용을 참고하여
            // View를 갱신(여기서의 View는 UI)


            // 문자열을을 정수로 변환
            int tIndex = System.Convert.ToInt32(tInfo.mImgRscId);
            mImgItem.sprite = CRyuMgr.GetInst().mSprites[tIndex];
            mTxtName.text = tInfo.mName;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // 이곳을 게임프로그램의 시작 부분이라고 가정하자
        // 아이템 도감 정보를 구축
        CRyuMgr.GetInst().CreateItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
