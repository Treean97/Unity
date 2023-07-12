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

    // ī�װ��� ���� �ٸ��޴����� ���� ū �켱���� ��ġ�� 11�̻� ���̳��� ���м��� �����
    [MenuItem("Menu / testMenu_2", false, 13)]
    static void TestMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
