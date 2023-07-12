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

public class CRyuMgr
{
    
    private static CRyuMgr mpInst = null;

    // ������ ���� ���� (�� ���⼭�� �����ϰ� �ϱ� ���� �̹����� ���ؼ��� �����Ѵ�)
    // Sprite : UI�� Unity2D���� ��밡���ϵ��� ����Ƽ���� �з��Ͽ� �������� Texture ����
    public Sprite[] mSprites = null;

    // �κ��丮 ����(ȹ�� ������ ��� ����)
    public List<CItemInfo> mInventory = new List<CItemInfo>();

    
    public void CreateItemList()
    {
        // Resources Ŭ������
        // Ư�� ������ Resources ������ �Բ� ����Ѵ�
        // ������ ������ ��ũ��Ʈ �󿡼� �޸𸮷� �ε��ϴ� ���̴�
        mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }



    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }

    
    public static CRyuMgr GetInst()
    {
        if(mpInst == null)
        {
            mpInst = new CRyuMgr();
        }

        return mpInst;
    }

}

