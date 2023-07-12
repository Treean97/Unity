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
        // ù ȭ�� ���
        mpTxtSpeaker.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mName;

        // ù ��� ���
        mpTxtDialogue.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue;

        // �ε��� ����
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

        // n��° ȭ�� ���
        mpTxtSpeaker.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mName;
        // n��° ��� ���
        mpTxtDialogue.text = CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue;
        // �ε��� ����
        if (mCurIndex < CDataMgr.GetInst().mDialogueInfos.Count - 1)
        {
            mCurIndex++;
        }
    }
}
