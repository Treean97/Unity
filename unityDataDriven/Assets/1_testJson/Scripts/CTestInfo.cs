using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    JsonUtility를 사용하기 위한 데이터 클래스 규칙

    1) Json데이터의 키의 이름과 똑같이 변수 이름을 만든다

    2) 해당 클래스에 직렬화를 적용해야한다
    [Serializable]
 
 */

[Serializable]
public class CTestInfo
{
    public string mName;
    public List<string> mStringList = null;
    public int mLevel;
    public int mExp;
}
