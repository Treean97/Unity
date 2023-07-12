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
            // �������� �ϳ��ۿ� �����Ƿ� �̷��� ����
            tInfo = CRyuMgr.GetInst().mInventory[0];
        }
        
        if(tInfo != null)
        {
            // Document�� ������ �����Ͽ�
            // View�� ����(���⼭�� View�� UI)


            // ���ڿ����� ������ ��ȯ
            int tIndex = System.Convert.ToInt32(tInfo.mImgRscId);
            mImgItem.sprite = CRyuMgr.GetInst().mSprites[tIndex];
            mTxtName.text = tInfo.mName;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // �̰��� �������α׷��� ���� �κ��̶�� ��������
        // ������ ���� ������ ����
        CRyuMgr.GetInst().CreateItemList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
