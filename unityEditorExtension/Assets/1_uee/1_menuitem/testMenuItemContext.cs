using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testMenuItemContext
{
    // 미리 정해져있는 단어디다. CONTEXT, Component
    // 컴포넌트에 문맥에 따른 메뉴를 만든다
    [MenuItem("CONTEXT/Component/testMenu_0")]
    static void testMenu_0()
    {
        Debug.Log("testMenu_0");
    }

    [MenuItem("CONTEXT/Transform/testMenu_1")]
    static void testMenu_1()
    {
        Debug.Log("testMenu_1");
    }

    [MenuItem("CONTEXT/testAttribute_4/testMenu_2")]
    static void testMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
