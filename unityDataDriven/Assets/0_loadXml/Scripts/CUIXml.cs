using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// for Xml
using System.Xml;
using System;


public class CUIXml : MonoBehaviour
{
    // xml ���
    public TMP_Text mpTxtXml = null;

    public CStageInfoList mStageInfoBundle = null;


    // Start is called before the first frame update
    void Start()
    {
        mStageInfoBundle = new CStageInfoList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickBtnLoadFromXml()
    {
        LoadFromXmlFile("stage_info_xml");
    }


    // Resources �����κ��� xml���� ������ �����͸� �ε��ϰ� �Ľ��ϴ� �Լ��̴�

    // �Ľ� parsing : ������ �����ڵ��� ���������ؼ� ��ȿ�� ���token���� �����س��� �۾�
    // �� �����͸� ������ �䱸��� ����ȭ�ϴ� ��
    bool LoadFromXmlFile(string tFileName)
    {
        Debug.Log($"LoadFromXmlFile {tFileName}");

        // xml('�ؽ�Ʈ ����'�� ����, �ڱ⸸�� �±׸� ����� �ڱ⸸�� ������ ���� �� �ִ� �Ծ�) ������ �ε��Ѵ�
        // ����Ƽ���� �ؽ�Ʈ ������ ������ ���� ������ �� Ŭ����
        TextAsset tTextAsset = null;    
        tTextAsset = Resources.Load<TextAsset>(tFileName);

        if(tTextAsset == null)
        {
            // ���� �ε� ����
            return false;
        }

        // ���� �ε� ����
        mpTxtXml.text = tTextAsset.text;

        // xml �����͸� �Ľ��Ѵ�(�뵵�� �°� �ؼ��Ѵ�)
        // Xml ���� ��ü�� ����
        XmlDocument tDoc = new XmlDocument();
        // ���ڿ� -> Xml ������ �����ͷ� �ٷ絵�� �Ѵ�
        tDoc.LoadXml(tTextAsset.text);

        CStageInfo tStageInfo = null;
        CUnitInfo tUnitInfo = null;

        // �����迭 ������ ǥ���, xml ���� ��ü���� �ֻ��� ��Ʈ��带 ��´�
        XmlElement tElementRoot = tDoc["response"];

        mStageInfoBundle.mStageInfos = new List<CStageInfo>();


        foreach(XmlElement tE in tElementRoot.ChildNodes)       // N���� stage info list
        {
            foreach(XmlElement tElementStageInfo in tE.ChildNodes)  // N���� stage info
            {
                tStageInfo = null;
                tStageInfo = new CStageInfo();

                tStageInfo.mId = System.Convert.ToInt32(tElementStageInfo.ChildNodes[0].InnerText);
                tStageInfo.mTotalEnemyCount = System.Convert.ToInt32(tElementStageInfo.ChildNodes[1].InnerText);

                if (tElementStageInfo.ChildNodes[1].ChildNodes.Count > 0)
                {
                    tStageInfo.mUnitInfos = new List<CUnitInfo>();

                    foreach (XmlElement tElementUnitInfo in tElementStageInfo.ChildNodes[2])
                    {
                        tUnitInfo = null;
                        tUnitInfo = new CUnitInfo();

                        tUnitInfo.mX = Convert.ToInt32(tElementUnitInfo.ChildNodes[0].InnerText);
                        tUnitInfo.mY = Convert.ToInt32(tElementUnitInfo.ChildNodes[1].InnerText);

                        tStageInfo.mUnitInfos.Add(tUnitInfo);
                    }

                }

                mStageInfoBundle.mStageInfos.Add(tStageInfo);
            }

        }

        // �Ľ��� �����͵��� ���(�α�)
        foreach (CStageInfo tS in mStageInfoBundle.mStageInfos)
        {
            Debug.Log($"stage id : {tS.mId.ToString()}");
            Debug.Log($"stage enemy count : {tS.mTotalEnemyCount.ToString()}");

            foreach(CUnitInfo tU in tS.mUnitInfos)
            {
                Debug.Log($"unit X : {tU.mX.ToString()}");
                Debug.Log($"unit Y : {tU.mY.ToString()}");
            }

        }



        return true;
    }

}
