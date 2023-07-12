using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class CUIJson : MonoBehaviour
{
    [SerializeField]
    TMP_Text mTextJson;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickBtnLoadFromJson()
    {
        LoadFromJsonFile("stage_info_json");
    }

    bool LoadFromJsonFile(string tFileName)
    {
        // xml('텍스트 형식'의 파일, 자기만의 태그를 만들어 자기만의 포맷을 만들 수 있는 규약) 에셋을 로드한다
        // 유니티에서 텍스트 형식의 에셋을 위해 마련해 둔 클래스
        TextAsset tTextAsset = null;
        tTextAsset = Resources.Load<TextAsset>(tFileName);

        if (tTextAsset == null)
        {
            // 에셋 로드 실패
            return false;
        }

        mTextJson.text = tTextAsset.text;

        // 파싱
        CJsonStageInfoList tInfoList = JsonUtility.FromJson<CJsonStageInfoList>(tTextAsset.text);

        // 데이터 출력
        foreach (var tS in tInfoList.stage_info)
        {
            Debug.Log($"stage id : {tS.id.ToString()}");
            Debug.Log($"stage enemy count : {tS.total_enemy_count.ToString()}");


            foreach (var tU in tS.unit_info)
            {
                Debug.Log($"x : {tU.x}");
                Debug.Log($"y : {tU.y}");

            }
        }


        return true;
    }
}
