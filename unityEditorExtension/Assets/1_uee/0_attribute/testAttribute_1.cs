using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티에서 제공하는 attribute 몇가지를 살펴보자

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
