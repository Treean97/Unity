using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CSOUI : MonoBehaviour
{
    CSOStageInfoList mStageInfoList = null;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mStageInfoList = AssetDatabase.LoadAssetAtPath<CSOStageInfoList>("Assets/Resources/stage_info_list_so.asset");

        Debug.Log($"Editor : stage_info_list.Count : {mStageInfoList.mStageInfos.Count.ToString()}");

        foreach (var t in mStageInfoList.mStageInfos)
        {
            Debug.Log($"stage id : {t.mId.ToString()}");
            Debug.Log($"stage enemy count : {t.mTotalEnemyCount.ToString()}");


            foreach (var s in t.mUnitInfos)
            {
                Debug.Log($"unit.x : {s.mX.ToString()}");
                Debug.Log($"unit.y : {s.mY.ToString()}");

            }
        }
#else
        mStageInfoList = Resources.Load<CSOStageInfoList>("stage_info_list_so");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
#if UNITY_EDITOR
#else
        GUI.Label(new Rect(0f,0f,300f,50f), $"In Game : stage_info_list.Count : {mStageInfoList.mStageInfos.Count.ToString()}");

        int ti = 0;
        int tj = 0;
        foreach (var t in mStageInfoList.mStageInfos)
        {
            GUI.Label(new Rect(0f, 20f + ti * 100f, 300f, 50f), $"id : {t.mId.ToString()}");
            GUI.Label(new Rect(0f, 40f + ti * 100f, 300f, 50f), $"stage enemy count : {t.mTotalEnemyCount.ToString()}");


            foreach (var s in t.mUnitInfos)
            {
                GUI.Label(new Rect(0f, 60f + ti * 100f + tj * 40f, 300f, 50f), $"unit.x : {s.mX.ToString()}");
                GUI.Label(new Rect(0f, 80f + ti * 100f + tj * 40f, 300f, 50f), $"unit.y : {s.mY.ToString()}");
                tj++;
            }

            ti++;
        }
#endif
    }
}
