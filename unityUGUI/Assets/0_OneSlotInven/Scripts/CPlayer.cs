using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public CUIInvenOneSlot mUIInven = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit tHit;

            if(Physics.Raycast(tRay, out tHit, Mathf.Infinity))
            {
                if(tHit.collider.CompareTag("tagItem"))
                {
                    Debug.Log("<color='red'>Aqcuire Item</color>");

                    CItemInfo tInfo = tHit.collider.GetComponent<CItem>().mInfo;

                    if(tInfo != null)
                    {
                        Debug.Log($"<color='green'>Id : {tInfo.mId}, Name : {tInfo.mName}, ImageIndex : {tInfo.mImgRscId}</color>");

                        // 아이템 획득
                        // 실제 데이터 Document 갱신
                        CRyuMgr.GetInst().mInventory.Add(tInfo);

                        // UI 갱신
                        mUIInven.BuildUI();

                        // 월드 상의 아이템 제거
                        Destroy(tHit.collider.gameObject);
                    }
                }

            }

        }

    }
}
