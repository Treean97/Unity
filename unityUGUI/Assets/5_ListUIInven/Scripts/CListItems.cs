using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CListItems : MonoBehaviour
{
    // prefab link
    [SerializeField]
    private CSlotItem PFSlotItem = null;


    // ������ N���� ���Ե��� ��Ƶ� ���� �迭
    // ���� �� �迭�� ũ�� ������ ����
    private List<CSlotItem> mListSlots = new List<CSlotItem>();


    // �ڽ��� ������ ���� ������Ʈ
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
        // ���� ������ ������ ����
        // clean
        foreach(var t in mListSlots)
        {
            // ���Ե��� Ŭ����
            Destroy(t.gameObject);
        }

        // �����迭�� ���ҵ��� Ŭ����
        mListSlots.Clear();

        // build
        // �ڷᱸ���� �ѱ��
        BuildSlotWithDicItemInven(CGameDataMgr.GetInst().mDicItemInventory);
    }

    // �����۵��� �ڷᱸ���� �Ű������� �޾� UI�� ����
    void BuildSlotWithDicItemInven(SortedDictionary<string, List<CItemData>> tDic)
    {
        // ������ ������ RectTransform
        RectTransform tSlotRectT = null;

        // ������ ������ ���� ��������
        CSlotItem tSlot = null;

        // �ϳ��� ������ �ʺ�, ���̸� ���ص�
        float tW = 1.0f;
        float tH = 1.0f;
        tW = ((RectTransform)(PFSlotItem.transform)).sizeDelta.x;
        tH = ((RectTransform)(PFSlotItem.transform)).sizeDelta.y;

        int ti = 0; // ������ ������ �ε���

        // �ʿ��� slot UI ����
        foreach(var t in tDic)
        {
            // �������� �ִ��� �˻�
            if (t.Value.Count > 0)
            {
                tSlot = null;
                // ������ �������� ����
                // ��ġ ������ ������ List
                tSlot = Instantiate<CSlotItem>(PFSlotItem, this.transform.position, Quaternion.identity);

                // ��ȯ ���� ������ �θ� �������� �����Ѵ�
                tSlot.transform.SetParent(this.transform);

                // slot UI�� �ܰ��� ����
                tSlotRectT = null;

                // UI������� �̹Ƿ� RectTransform���� �ٷ�� �Ѵ�
                tSlotRectT = tSlotRectT.transform as RectTransform;

                // ��ġ ���� Left, top�� �����������Ͽ� y�� �Ϲ����� �޸����� ��
                tSlotRectT.anchoredPosition = new Vector2(0f, 0f - ti * tH);

                // ���� ������ ������ �ʺ�, ���� ����
                tSlotRectT.sizeDelta = new Vector2(tW, tH);

                // ũ��� ������ �ະ�� 1
                tSlot.transform.localScale = Vector3.one;

                // data�� ����
                // ���� ������ �������̶�� ��� ���ٰ� �����Ǿ� �����Ƿ� ù ��° �������� ������ ����
                tSlot.SetItemData(t.Value[0]);
                // �����迭�� ������ ������ ���� ������ ������ ��´�
                tSlot.SetItemCount(t.Value.Count);

                // ������ ����
                tSlot.SetList(this);
                


                mListSlots.Add(tSlot);

                ti++;
            }
        }

        // instListItems�� ���� ����
        RectTransform tListRectT = null;

        tListRectT = this.transform as RectTransform;

        // �� �κп����� �̹� ti�� ���� ������ ī��Ʈ �Ǿ� �����Ƿ�
        // �Ʒ��� ���� ����Ʈ�� ���̸� ���Ѵ�
        tListRectT.sizeDelta = new Vector2(tW, tH * ti);
        
        // �ܰ��� �����ϴ� �۾��� ��� �������Ƿ�
        // slot UI���� ������ ������ �����Ѵ�
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
