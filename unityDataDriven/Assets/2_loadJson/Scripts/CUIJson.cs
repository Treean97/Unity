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
        // xml('�ؽ�Ʈ ����'�� ����, �ڱ⸸�� �±׸� ����� �ڱ⸸�� ������ ���� �� �ִ� �Ծ�) ������ �ε��Ѵ�
        // ����Ƽ���� �ؽ�Ʈ ������ ������ ���� ������ �� Ŭ����
        TextAsset tTextAsset = null;
        tTextAsset = Resources.Load<TextAsset>(tFileName);

        if (tTextAsset == null)
        {
            // ���� �ε� ����
            return false;
        }

        mTextJson.text = tTextAsset.text;

        // �Ľ�
        CJsonStageInfoList tInfoList = JsonUtility.FromJson<CJsonStageInfoList>(tTextAsset.text);

        // ������ ���
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
