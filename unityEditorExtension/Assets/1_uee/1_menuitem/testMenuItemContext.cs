using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testMenuItemContext
{
    // �̸� �������ִ� �ܾ���. CONTEXT, Component
    // ������Ʈ�� ���ƿ� ���� �޴��� �����
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
