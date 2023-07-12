using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// 싱글톤 패턴이 적용된 클래스
// 여기서는 대사 데이터 관리자로 가정


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
            // 에셋 로드 실패
            Debug.Log("Asset Load Fail");
            return;
        }

        // 에셋 로드 성공
        Debug.Log(tTextAsset.text);

        // Xml로 파싱
        XmlDocument tDoc = new XmlDocument();
        tDoc.LoadXml(tTextAsset.text);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];

        int ti = 0;     // 카운트용 변수
        int tCount = tElementRoot.ChildNodes.Count;  // 총 대사 갯수

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

    // 전역적으로 관리되는 대사 정보객체를 생성
    public void CreateObj()
    {
        mDialogueInfos = new List<CDialogueInfo>();

        // 에셋이므로 확장자명은 명시하지 않는다
        LoadDialogueInfos("dialogue_list");
    }

}
