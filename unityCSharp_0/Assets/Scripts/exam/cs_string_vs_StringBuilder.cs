using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/*
    string vs StringBuilder

 
 */


public class cs_string_vs_StringBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // step_0
        // 이 코드는 좋은 코드가 아니다
        // 이 코드는 마치 문자열을 추가하는 것처럼 보이지만
        // 추가하는 것이 아니다 
        // string은 변경불가능한 문자열을 다루는 형태로 동작한다. (c로 따지자면 const char*)
        // 즉 이미 있던 문자열은 삭제(가비지 컬렉팅)대상이 되고 ,새로운 문자열이 만들어져 대체 되는 것이다

        int tAge = 21;
        string tMsg_0 = "I am ";
        tMsg_0 += "a good ";
        tMsg_0 += "boy. ";
        tMsg_0 += "This is ";
        tMsg_0 += tAge.ToString();

        Debug.Log(tMsg_0);

        // step_1
        // 그래서 step_0의 표현보다는 아래와 같이 표현하는 것이 더 낫다
        string tMsg_1 = string.Format("I am a good boy. This is {0}", tAge);
        // c로 치면 printf
        Debug.Log(tMsg_1);

        string tMsg_1_0 = $"I am a good boy. This is {tAge.ToString()}";
        Debug.Log(tMsg_1_0);


        // step_2
        // 아예 step_0과 같은 경우를 위해 만들어진 클래스가 바로 StringBuilder이다
        // 수정 가능한 문자열 타입이다
        // 최종적으로는 변경 불가능한 문자열 string이 만들어 진다
        StringBuilder tMsg_2 = new StringBuilder("I am ");
        tMsg_2.Append("a good ");
        tMsg_2.Append("boy. ");
        tMsg_2.Append("This is ");
        tMsg_2.Append(tAge.ToString());

        Debug.Log(tMsg_2.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
