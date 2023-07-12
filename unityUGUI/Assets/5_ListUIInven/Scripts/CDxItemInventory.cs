using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDxItemInventory : MonoBehaviour
{
    [SerializeField]
    CListItems mpListItems = null;  // ����Ʈ UI

    // ������ ������ ���� ǥ��
    [SerializeField]
    TMPro.TMP_Text mTxtNameSelect = null;

    [SerializeField]
    TMPro.TMP_Text mTxtDescSelect = null;
    
    // Start is called before the first frame update
    void Start()
    {
        mpListItems.SetDxItemInventory(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildUI()
    {
        mpListItems.BuildUI();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }


    public void Hide()
    {
        this.gameObject.SetActive(false);
    }


    public bool IsShow()
    {
        return this.gameObject.activeInHierarchy;
    }


    public void DoUseItem(CItemData tItemData)
    {
        Debug.Log("<color='red'>DxItemInventory.DoUseItem</color>");

        mTxtNameSelect.text = tItemData.mName;
        mTxtDescSelect.text = tItemData.mDesc;
    }
}
