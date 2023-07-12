using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataDriven/Create CSOStageInfoList")]
public class CSOStageInfoList : ScriptableObject
{
    public List<CSOStageInfo> mStageInfos;
}
