using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트 컴포넌트는 반드시 Animator 컴포넌트를 요구하도록 만드는 attribute
[RequireComponent(typeof(Animator))]
public class testAttribute_4 : MonoBehaviour
{
    Animator mAnim = null;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();
    }

}
