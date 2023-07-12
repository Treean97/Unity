using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Json JavaScript Object Notation
    ���� �ڹٽ�ũ��Ʈ ���� ������Ʈ ������ ǥ���� �� ���� �����̾���
    ������ ������ �������� �ؽ�Ʈ ������ ���� �԰��̴�

    Xml�� ��ü�Ѵ�
    
    �ֿ� ���� ������Ҵ� ������ ����

    {}          ������Ʈ�� ��Ÿ����
    Ű : ��     ������ �����͸� ������
    Ű          ���ڿ� ����
    []          �迭�� ��Ÿ����

    ������ �����ʹ� ,�� ����

    �迭�� ���ҵ� , �� ����

    Json �԰��� �뼼�� �� ������ �ؽ�Ʈ ������ �������� ������ ���̳ʸ� ������ �������� �������� �������� ã�ұ� ����

 */
public class CUITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Json -> ����� ���� Ŭ���� Ÿ���� ��ü 
    public void OnClickBtnFromJson()
    {
        // �ҽ��ڵ� ���� ���ڿ� ���·� ���� json�԰��� �ؽ�Ʈ ������
        string tJson = @"{
            ""mName"" : ""�̸�"",
            ""mStringList"":
            [
            ""weapon_0"",
            ""weapon_1""
            ],
            ""mLevel"":10,
            ""mExp"":1024
                
        }";
        
        // JsonUtility : ����Ƽ���� �����ϴ� Json Ŭ����
        CTestInfo tInfo = JsonUtility.FromJson<CTestInfo>(tJson);

        // ���
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach(var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }

    // ����� ���� Ŭ���� Ÿ���� ��ü -> Json
    public void OnClickBtnToJson()
    {
        CTestInfo tInfo = new CTestInfo();

        tInfo.mName = "�μ�";
        tInfo.mLevel = 5;
        tInfo.mExp = 123;
        tInfo.mStringList = new List<string>();
        tInfo.mStringList.Add("weapon_123");
        tInfo.mStringList.Add("weapon_asd");

        string tJson = JsonUtility.ToJson(tInfo);

        Debug.Log(tJson);
    }

    public void OnClickBtnOverwriteFromJson()
    {
        string tJson = @"{
            ""mName"" : ""�̸�"",
            ""mStringList"":
            [
            ""weapon_0"",
            ""weapon_1""
            ],
            ""mLevel"":10,
            ""mExp"":1024
                
        }";

        // ������ ������
        // JsonUtility : ����Ƽ���� �����ϴ� Json Ŭ����
        CTestInfo tInfo = JsonUtility.FromJson<CTestInfo>(tJson);

        // ���
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }

        // ������ �����
        string tJson_1 = @"{
            ""mName"" : ""qwerty"",
            ""mStringList"":
            [
            ""weapon_123"",
            ""weapon_456""
            ],
            ""mLevel"":50,
            ""mExp"":123
                
        }";

        JsonUtility.FromJsonOverwrite(tJson_1, tInfo);

        // ���
        Debug.Log("=============");
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }
}
