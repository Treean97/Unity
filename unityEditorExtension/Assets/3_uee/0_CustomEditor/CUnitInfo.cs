using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 데이터 클래스 용도의 클래스
[Serializable]
public class CUnitInfo
{

    [Range(0, 255)]
    public int mBaseAP = 0;

    [Range(0, 255)]
    public int mEndurance = 0;

    [Range(0, 255)]
    public int mStr = 0;

    // 프로퍼티
    public int _AP
    {
        // 임의의 수식
        get { return mBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16); }
    }
}
