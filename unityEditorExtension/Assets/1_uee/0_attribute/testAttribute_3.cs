using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티에서 제공하는 attribute 몇가지를 살펴보자

public class testAttribute_3 : MonoBehaviour
{
    [SerializeField]
    CPlayer mPlayer = null;

    // embedded class
    [Serializable]
    public class CPlayer
    {
        [Tooltip("플레이어의 이름을 나타냅니다.")]
        public string mName = "player name";
        [Tooltip("플레이어의 체력을 나타냅니다.")]
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
