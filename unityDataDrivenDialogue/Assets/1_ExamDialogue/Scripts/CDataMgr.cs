using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// �̱��� ������ ����� Ŭ����
// ���⼭�� ��� ������ �����ڷ� ����


public class CDataMgr
{
    private static CDataMgr mpInst = null;

    public List<CDialogueInfo> mDialogueInfos = null;

    private CDataMgr()
    {

    }


    public static CDataMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CDataMgr();
        }

        return mpInst;

    }

    public void LoadDialogueInfos(string tAssetName)
    {
        TextAsset tTextAsset = null;
        tTextAsset = Resources.Load<TextAsset>(tAssetName);

        if(tTextAsset == null)
        {
            // ���� �ε� ����
            Debug.Log("Asset Load Fail");
            return;
        }

        // ���� �ε� ����
        Debug.Log(tTextAsset.text);

        // Xml�� �Ľ�
        XmlDocument tDoc = new XmlDocument();
        tDoc.LoadXml(tTextAsset.text);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];

        int ti = 0;     // ī��Ʈ�� ����
        int tCount = tElementRoot.ChildNodes.Count;  // �� ��� ����

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;

        for (ti = 0; ti < tCount; ti++)
        {
            tElement_0 = tElementRoot.ChildNodes[ti] as XmlElement;

            tInfo = new CDialogueInfo();

            tInfo.mId = Convert.ToInt32(tElement_0.ChildNodes[0].InnerText);
            tInfo.mName = tElement_0.ChildNodes[1].InnerText;
            tInfo.mDialogue = tElement_0.ChildNodes[2].InnerText;

            mDialogueInfos.Add(tInfo);
        }
    }

    // ���������� �����Ǵ� ��� ������ü�� ����
    public void CreateObj()
    {
        mDialogueInfos = new List<CDialogueInfo>();

        // �����̹Ƿ� Ȯ���ڸ��� ������� �ʴ´�
        LoadDialogueInfos("dialogue_list");
    }

}
