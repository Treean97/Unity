using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// for Xml
using System.Xml;
using System;


public class CUIXml : MonoBehaviour
{
    // xml 출력
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


    // Resources 폴더로부터 xml파일 에셋의 데이터를 로드하고 파싱하는 함수이다

    // 파싱 parsing : 임의의 구분자들을 기준으로해서 유효한 요소token들을 추출해내는 작업
    // 즉 데이터를 임의의 요구대로 조직화하는 것
    bool LoadFromXmlFile(string tFileName)
    {
        Debug.Log($"LoadFromXmlFile {tFileName}");

        // xml('텍스트 형식'의 파일, 자기만의 태그를 만들어 자기만의 포맷을 만들 수 있는 규약) 에셋을 로드한다
        // 유니티에서 텍스트 형식의 에셋을 위해 마련해 둔 클래스
        TextAsset tTextAsset = null;    
        tTextAsset = Resources.Load<TextAsset>(tFileName);

        if(tTextAsset == null)
        {
            // 에셋 로드 실패
            return false;
        }

        // 에셋 로드 성공
        mpTxtXml.text = tTextAsset.text;

        // xml 데이터를 파싱한다(용도에 맞게 해석한다)
        // Xml 문서 객체를 생성
        XmlDocument tDoc = new XmlDocument();
        // 문자열 -> Xml 형태의 데이터로 다루도록 한다
        tDoc.LoadXml(tTextAsset.text);

        CStageInfo tStageInfo = null;
        CUnitInfo tUnitInfo = null;

        // 연관배열 형태의 표기법, xml 문서 객체에서 최상위 루트노드를 얻는다
        XmlElement tElementRoot = tDoc["response"];

        mStageInfoBundle.mStageInfos = new List<CStageInfo>();


        foreach(XmlElement tE in tElementRoot.ChildNodes)       // N개의 stage info list
        {
            foreach(XmlElement tElementStageInfo in tE.ChildNodes)  // N개의 stage info
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

        // 파싱한 데이터들을 출력(로그)
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
