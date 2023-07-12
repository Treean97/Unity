using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE_JOB
{
    JOB_KNIGHT,
    JOB_ARCHOR,
    JOB_MAGIC,
    JOB_PALADIN,
}

[Serializable]
public class CGameUnitInfo
{
    public string mName = "ironman";
    public int mLevel = 0;
    public TYPE_JOB mTypeJob = TYPE_JOB.JOB_KNIGHT;
}
