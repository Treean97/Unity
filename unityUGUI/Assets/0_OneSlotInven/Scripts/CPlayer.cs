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

                        // ������ ȹ��
                        // ���� ������ Document ����
                        CRyuMgr.GetInst().mInventory.Add(tInfo);

                        // UI ����
                        mUIInven.BuildUI();

                        // ���� ���� ������ ����
                        Destroy(tHit.collider.gameObject);
                    }
                }

            }

        }

    }
}
