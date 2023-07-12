using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CSOStageInfo
{
    public int mId = 0;
    public int mTotalEnemyCount = 0;

    public List<CSOUnitInfo> mUnitInfos = null;
}
