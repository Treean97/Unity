using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ������ Ŭ���� �뵵�� Ŭ����
[Serializable]
public class CUnitInfo
{

    [Range(0, 255)]
    public int mBaseAP = 0;

    [Range(0, 255)]
    public int mEndurance = 0;

    [Range(0, 255)]
    public int mStr = 0;

    // ������Ƽ
    public int _AP
    {
        // ������ ����
        get { return mBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16); }
    }
}
