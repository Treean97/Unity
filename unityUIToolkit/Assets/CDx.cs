using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CDx : MonoBehaviour
{
    // 스크립트에서 제어할 버튼 객체를 준비
    Button mBtnClose = null;

    // 스크립트에서 제어할 객체 준비
    VisualElement mBg = null;

    VisualElement mOneSlot = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // 게임 오브젝트가 인스턴스화되고 활성될 때 호출
    private void OnEnable()
    {
        // uxml 문서의 최상단 루트를 얻는다. 이것은 uxml 문서를 추상화해놓은 것
        var tRoot = GetComponent<UIDocument>().rootVisualElement;

        // 문서에서 버튼 객체를 검색
        mBtnClose = tRoot.Q<Button>("instBtnClose");

        // 기능 부여
        mBtnClose.RegisterCallback<ClickEvent>(OnClickBtnClose);

        Debug.Log("OnEnable");

        mOneSlot = tRoot.Q<VisualElement>("instOneSlot");

        Invoke("OnHide", 1.0f);
        
    }

    // 게임 오브젝트가 인스턴스화되고 비활성될 때 호출
    private void OnDisable()
    {
        // 콜백함수 등록 해제(사용한 자원을 해제)
        mBtnClose.UnregisterCallback<ClickEvent>(OnClickBtnClose);
        mOneSlot.UnregisterCallback<TransitionEndEvent>(OnEndAni);

        Debug.Log("OnDisable");
    }

    void OnClickBtnClose(ClickEvent t)
    {
        if (mBtnClose != null)
        {
            mOneSlot.RemoveFromClassList("dxHide");
            mOneSlot.AddToClassList("dxShow");

            mOneSlot.RegisterCallback<TransitionEndEvent>(OnEndAni);

            
        }
                
    }

    void OnEndAni(TransitionEndEvent t)
    {
        gameObject.SetActive(false);
    }


    void OnHide()
    {
        mOneSlot.AddToClassList("dxHide");
    }

    

    // Update is called once per frame
    void Update()
    {

    }
}
