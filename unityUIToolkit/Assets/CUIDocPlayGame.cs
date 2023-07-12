using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// for UI Toolkit
using UnityEngine.UIElements;

public class CUIDocPlayGame : MonoBehaviour
{
    [SerializeField]
    GameObject mDx = null;

    // 스크립트에서 제어할 버튼 객체를 준비
    Button mBtnTest = null;

    // 스크립트에서 제어할 객체 준비
    VisualElement mBg = null;

    // Start is called before the first frame update
    void Start()
    {
        // uxml 문서의 최상단 루트를 얻는다. 이것은 uxml 문서를 추상화해놓은 것
        var tRoot = GetComponent<UIDocument>().rootVisualElement;

        // 문서에서 버튼 객체를 검색
        mBtnTest = tRoot.Q<Button>("instBtnTest");

        // 기능 부여
        mBtnTest.RegisterCallback<ClickEvent>(OnClickBtnTest);

        // 문서에서 VisualElement 객체 검색
        mBg = tRoot.Q<VisualElement>("bg");

        // 기능 부여
        mBg.RegisterCallback<ClickEvent>(OnClickBtnTest);

    }

    void OnClickBtnTest(ClickEvent t)
    {
        if(mBtnTest != null)
        {
            // Debug.Log("CUIDocPlayGame.OnClickBtnTest");

            // 해당 UIDocument 게임 오브젝트를 비활성화
            // gameObject.SetActive(false);


            // mBg의 가시성 제어
            // mBg.style.display = DisplayStyle.None;

            // 대화상자 show
            mDx.gameObject.SetActive(true);
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

}
