using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CJsonStageInfo
{
    public int id;
    public int total_enemy_count;
    public List<CJsonUnitInfo> unit_info;
}
