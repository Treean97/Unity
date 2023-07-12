using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    �̱��� ���� ����
    �̱��� : ��ü�� �ִ� ���� ������ 1���� �����ϴ� ���� ������ ����
    
    1) mpInstance�� static�� �����Ѵ�
    2) �����ڴ� private
    3) GetInstance �Լ��ȿ��� ��ü�� 1���� ���� �����ϴ� �Ǵ� ������ �����Ѵ�

    C#���� ��ü�� ���� �ܰ�
    
    ������ Ÿ������ 'ù ��° �ν��Ͻ�'�� ������ �� ����Ǵ� ����
    
    ���� ���� �ܰ�
        1. ���� ������ �������(�޸�)�� 0���� �ʱ�ȭ
        2. ���� ������ ���� �ʱ�ȭ ������ ����
        3. ���� ������ ����
            ���� ��Ӱ�����
            ��. ���̽� Ŭ����(�θ�Ŭ����)�� ���� ������ ����
            ��. �ڽ��� ���� ������ ����
 
    ===========================================

    �ν��Ͻ� ���� �ܰ�
        1. �ν��Ͻ� ������ �������(�޸�)�� 0���� �ʱ�ȭ
        2. �ν��Ͻ� ������ ���� �ʱ�ȭ ������ ����
        3. �ν��Ͻ� ������ ����
            ���� ��Ӱ�����
            ��. ���̽� Ŭ����(�θ�Ŭ����)�� �ν��Ͻ� ������ ����
            ��. �ڽ��� �ν��Ͻ� ������ ����
 */

public class CGameDataMgr
{
    private static CGameDataMgr mpInst = null;
    
    public Sprite[] mSprites = null;

    public List<CItemInfo> mInventory = new List<CItemInfo>();

    // �κ��丮 ����(ȹ�� ������ ��� ����)
    // ���� ������ �����ʹ� ���ε��� ������ ���̰�
    // UI���� ���� ������ �������̸� �� ���Ը� �Ҵ��Ͽ� ������ �� (������ ǥ��)
    public SortedDictionary<string, List<CItemData>> mDicItemInventory = new SortedDictionary<string, List<CItemData>>();
    
    public void CreateItemList()
    {
        // mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }

    public void AddItemToInven(CItemData tData)
    {
        // ����Ÿ���� ��ü�̹Ƿ� ���� �����Ͽ� ���� �����ϵ��� �ϰڴ�
        CItemData t = new CItemData();

        t = tData;

        Debug.Log($"AddItemToInven / id : {t.mId.ToString()}, name : {t.mName}");

        List<CItemData> tList = null;

        // mId�� Ű�� ��ڴ�
        string tKey = t.mId.ToString();

        
        if (mDicItemInventory.ContainsKey(tKey))
        {
            // ���� �̹� �����ϴ� �������̶�� ��ųʸ��� �׸��� ã�� 
            // �� �׸��� �����迭�� �߰��Ѵ�
            tList = mDicItemInventory[tKey];
            tList.Add(t);
        }
        else
        {
            // ���� �������� �ʴ� �������̶��
            // ���Ӱ� �׸��� �����Ѵ�
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

