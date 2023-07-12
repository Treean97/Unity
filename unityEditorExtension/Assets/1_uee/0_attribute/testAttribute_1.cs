using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ���� �����ϴ� attribute ����� ���캸��

public class testAttribute_1 : MonoBehaviour
{
    [ContextMenuItem("Random", "DoRandomNumber")]
    [ContextMenuItem("Reset", "ResetNumber")]


    [SerializeField]
    int mNumber = 0;

    void DoRandomNumber()
    {
        mNumber = Random.Range(0, 100);
    }

    void ResetNumber()
    {
        mNumber = 0;
    }
}
