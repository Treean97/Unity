using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testMenuItem 
{
    [MenuItem("Menu / testMenu_0", false, 2)]
    static void TestMenu_0()
    {
        Debug.Log("testMenu_0");
    }

    [MenuItem("Menu / testMenu_1", false, 1)]
    static void TestMenu_1()
    {
        Debug.Log("testMenu_1");
    }

    // 카테고리에 속한 다른메뉴들의 가장 큰 우선순위 수치와 11이상 차이나면 구분선이 생긴다
    [MenuItem("Menu / testMenu_2", false, 13)]
    static void TestMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
