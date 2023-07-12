using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    [SerializeField]
    TMP_Text mpTxtDialogue = null;

    [SerializeField]
    TMP_Text mpTxtSpeaker = null;

    int mCurIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        CDataMgr.GetInst().CreateObj();
        // 첫 화자 출력
        mpTxtSpeaker.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mName;

        // 첫 대사 출력
        mpTxtDialogue.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue;

        // 인덱스 증가
        if (mCurIndex <= CDataMgr.GetInst().mDialogueInfos.Count)
        {
            mCurIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBtnNextDialogue()
    {
        Debug.Log("next");

        // n번째 화자 출력
        mpTxtSpeaker.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mName;
        // n번째 대사 출력
        mpTxtDialogue.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue;
        // 인덱스 증가
        if (mCurIndex < CDataMgr.GetInst().mDialogueInfos.Count - 1)
        {
            mCurIndex++;
        }
    }
}
