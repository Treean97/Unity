using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ ������Ʈ�� �ݵ�� Animator ������Ʈ�� �䱸�ϵ��� ����� attribute
[RequireComponent(typeof(Animator))]
public class testAttribute_4 : MonoBehaviour
{
    Animator mAnim = null;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();
    }

}
