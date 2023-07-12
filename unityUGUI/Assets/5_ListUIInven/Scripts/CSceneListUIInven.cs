using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneListUIInven : MonoBehaviour
{
    [SerializeField]
    CDxItemInventory mInven = null;


    // Start is called before the first frame update
    void Start()
    {
        CItemData t = null;
        t = new CItemData();
        t.mId = 0;
        t.mName = "사과";
        t.mDesc = "사과이다";
        t.mCriticalRatio = 100;
        t.mRscId = 0;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 0;
        t.mName = "사과";
        t.mDesc = "사과이다";
        t.mCriticalRatio = 100;
        t.mRscId = 0;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 1;
        t.mName = "배";
        t.mDesc = "배다";
        t.mCriticalRatio = 50;
        t.mRscId = 1;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 2;
        t.mName = "포도";
        t.mDesc = "포도다";
        t.mCriticalRatio = 200;
        t.mRscId = 2;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 3;
        t.mName = "수박";
        t.mDesc = "수박이다";
        t.mCriticalRatio = 500;
        t.mRscId = 3;

        CGameDataMgr.GetInst().AddItemToInven(t);

        // UI구축
        mInven.BuildUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 100, 240, 100), "Test Dx Show"))
        {
            mInven.Show();
        }
    }

}
