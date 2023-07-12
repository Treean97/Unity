using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 리플렉션 Reflection : 실행 중 타입에 대한 정보를 조회할 수 있는 기능
using System.Reflection;

/*
    attribute문법

    문법구성요소(클래스, 멤버변수, 멤버함수,...)에 대해
    부가적인 정보를 담아두는 문법(이를테면 Serializable)

    이 예시는 그 중에서도
    custom attribute의 용법과 기전을 살펴보자
 
    유니티 에디터는
    유니티 엔진에 정의된 속성들을 해석해서
    유니티 에디터에서 어떻게 보이는지 등을 결정하여 보여준다
 */


class CTest
{
    // Doit함수에 부가적인 정보를 CAttribute속성을 적용하여 추가했다
    [CAttribute("strength", _Value = "1004")]
    public void Doit()
    {
        Debug.Log("CTest.Doit");
    }
}

// System.Attribute 클래스를 상속받아 사용자 정의 attribute를 만든다
class CAttribute : System.Attribute
{
    string mString = "";
    string mValue = "";

    // 매개변수 있는 생성자
    public CAttribute(string tString)
    {
        mString = tString;
    }

    // 프로퍼티
    public string _Value
    {
        get 
        {
            return $"{mString}, : {mValue}"; 
        }
        set
        {
            mValue = value; 
        }
    }

}

public class examCustomAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CTest tTest = new CTest();
        tTest.Doit();

        // typeof연산자 : 타입에 대한 정보를 조회할 수 있는 연산자
        // 리플렉션 기능 중 하나
        // 실행 중에 함수 정보들을 얻자
        MethodInfo[] tArray = typeof(CTest).GetMethods();
        foreach(var t in tArray)
        {
            Debug.Log(t);
            object[] tObjects = t.GetCustomAttributes(false);
            foreach(CAttribute tObj in tObjects)
            {
                Debug.Log(tObj._Value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
