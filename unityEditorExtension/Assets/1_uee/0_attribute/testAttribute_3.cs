using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ���� �����ϴ� attribute ����� ���캸��

public class testAttribute_3 : MonoBehaviour
{
    [SerializeField]
    CPlayer mPlayer = null;

    // embedded class
    [Serializable]
    public class CPlayer
    {
        [Tooltip("�÷��̾��� �̸��� ��Ÿ���ϴ�.")]
        public string mName = "player name";
        [Tooltip("�÷��̾��� ü���� ��Ÿ���ϴ�.")]
        public int mHP = 100;
    }

    [Header("Game Settings")]
    [SerializeField]
    Color mColorBackground = Color.red;

    public int mA = 1024;

    [SerializeField]
    int mB = 1024;

    [HideInInspector]
    public int mC = 1024;


}
