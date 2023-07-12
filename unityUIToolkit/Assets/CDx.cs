using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CDx : MonoBehaviour
{
    // ��ũ��Ʈ���� ������ ��ư ��ü�� �غ�
    Button mBtnClose = null;

    // ��ũ��Ʈ���� ������ ��ü �غ�
    VisualElement mBg = null;

    VisualElement mOneSlot = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // ���� ������Ʈ�� �ν��Ͻ�ȭ�ǰ� Ȱ���� �� ȣ��
    private void OnEnable()
    {
        // uxml ������ �ֻ�� ��Ʈ�� ��´�. �̰��� uxml ������ �߻�ȭ�س��� ��
        var tRoot = GetComponent<UIDocument>().rootVisualElement;

        // �������� ��ư ��ü�� �˻�
        mBtnClose = tRoot.Q<Button>("instBtnClose");

        // ��� �ο�
        mBtnClose.RegisterCallback<ClickEvent>(OnClickBtnClose);

        Debug.Log("OnEnable");

        mOneSlot = tRoot.Q<VisualElement>("instOneSlot");

        Invoke("OnHide", 1.0f);
        
    }

    // ���� ������Ʈ�� �ν��Ͻ�ȭ�ǰ� ��Ȱ���� �� ȣ��
    private void OnDisable()
    {
        // �ݹ��Լ� ��� ����(����� �ڿ��� ����)
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
