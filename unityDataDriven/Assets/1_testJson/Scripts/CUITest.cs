using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Json JavaScript Object Notation
    원래 자바스크립트 언어에서 오브젝트 개념을 표기할 때 쓰는 문법이었다
    하지만 지금은 범용적인 텍스트 형식의 포맷 규격이다

    Xml을 대체한다
    
    주요 문법 구성요소는 다음과 같다

    {}          오브젝트를 나타낸다
    키 : 값     형태의 데이터를 가진다
    키          문자열 형태
    []          배열을 나타낸다

    각각의 데이터는 ,로 구분

    배열의 원소도 , 로 구분

    Json 규격이 대세가 된 이유는 텍스트 형식의 데이터의 장점과 바이너리 형식의 데이터의 장점에서 절충점을 찾았기 때문

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

    // Json -> 사용자 정의 클래스 타입의 객체 
    public void OnClickBtnFromJson()
    {
        // 소스코드 내에 문자열 형태로 만든 json규격의 텍스트 데이터
        string tJson = @"{
            ""mName"" : ""이름"",
            ""mStringList"":
            [
            ""weapon_0"",
            ""weapon_1""
            ],
            ""mLevel"":10,
            ""mExp"":1024
                
        }";
        
        // JsonUtility : 유니티에서 제공하는 Json 클래스
        CTestInfo tInfo = JsonUtility.FromJson<CTestInfo>(tJson);

        // 출력
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach(var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }

    // 사용자 정의 클래스 타입의 객체 -> Json
    public void OnClickBtnToJson()
    {
        CTestInfo tInfo = new CTestInfo();

        tInfo.mName = "민수";
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
            ""mName"" : ""이름"",
            ""mStringList"":
            [
            ""weapon_0"",
            ""weapon_1""
            ],
            ""mLevel"":10,
            ""mExp"":1024
                
        }";

        // 기존의 데이터
        // JsonUtility : 유니티에서 제공하는 Json 클래스
        CTestInfo tInfo = JsonUtility.FromJson<CTestInfo>(tJson);

        // 출력
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }

        // 데이터 덮어쓰기
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

        // 출력
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
