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

    // ��ũ��Ʈ���� ������ ��ư ��ü�� �غ�
    Button mBtnTest = null;

    // ��ũ��Ʈ���� ������ ��ü �غ�
    VisualElement mBg = null;

    // Start is called before the first frame update
    void Start()
    {
        // uxml ������ �ֻ�� ��Ʈ�� ��´�. �̰��� uxml ������ �߻�ȭ�س��� ��
        var tRoot = GetComponent<UIDocument>().rootVisualElement;

        // �������� ��ư ��ü�� �˻�
        mBtnTest = tRoot.Q<Button>("instBtnTest");

        // ��� �ο�
        mBtnTest.RegisterCallback<ClickEvent>(OnClickBtnTest);

        // �������� VisualElement ��ü �˻�
        mBg = tRoot.Q<VisualElement>("bg");

        // ��� �ο�
        mBg.RegisterCallback<ClickEvent>(OnClickBtnTest);

    }

    void OnClickBtnTest(ClickEvent t)
    {
        if(mBtnTest != null)
        {
            // Debug.Log("CUIDocPlayGame.OnClickBtnTest");

            // �ش� UIDocument ���� ������Ʈ�� ��Ȱ��ȭ
            // gameObject.SetActive(false);


            // mBg�� ���ü� ����
            // mBg.style.display = DisplayStyle.None;

            // ��ȭ���� show
            mDx.gameObject.SetActive(true);
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

}
