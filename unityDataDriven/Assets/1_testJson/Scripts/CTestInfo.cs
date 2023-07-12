using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    JsonUtility�� ����ϱ� ���� ������ Ŭ���� ��Ģ

    1) Json�������� Ű�� �̸��� �Ȱ��� ���� �̸��� �����

    2) �ش� Ŭ������ ����ȭ�� �����ؾ��Ѵ�
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
