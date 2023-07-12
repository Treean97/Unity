using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class CItemData
{
    public int mId = 0;             // 아이템의 고유 식별자
    public string mName = "";       // 아이템의 이름
    public string mDesc = "";       // 아이템의 설명
    public int mRscId = 0;          // 아이템의 UI상 이미지 정보

    // 그 외 여러 스탯들의 관한 정보도 있을 수 있음
    public int mCriticalRatio = 0;




}
