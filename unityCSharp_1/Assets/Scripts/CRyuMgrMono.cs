using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrMono : MonoBehaviour
{
    // 선언 시 할당할 것이 아니고 생성자에서 할당할 것도 아니므로
    // readonly는 적용하지 않았다
    private static CRyuMgrMono mpInst = null;

    int mTestExp = 888;
    // 프로퍼티
    public static CRyuMgrMono GetInst
    {
        get
        {
            if(mpInst == null)
            {
                // FindObjectOfType<T>
                // 해당 클래스 스크립트 컴포넌트가 부착된 게임 오브젝트를 검색하여 찾는 것
                mpInst = FindObjectOfType<CRyuMgrMono>() as CRyuMgrMono;
            }

            return mpInst;
        }
    }

    // 게임오브젝트가 생성되면 가장 먼저 호출되는 이벤트 함수
    // MonoBehaviour의 생성자 역할 정도를 한다라고 보면 된다
    private void Awake()
    {
        if(mpInst == null)
        {
            mpInst = this;
        }
        else if(mpInst != null)
        {
            // Destroy
            // 유니티에서 준비해둔, 게임 오브젝트를 소멸시키는 함수
            Destroy(this.gameObject);
        }

        // 유니티에서 준비해둔, 게임 오브젝트를 유지시키는 함수(이를테면 장면전환시에도 삭제하지 않고 유지)
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 쌩 클래스, GetInst호출시 만들어진다
        CRyuMgr.GetInst();

        // 쌩 클래스, 정적생성자를 이용하여 mpInst선언 시 할당되어 만들어진다
        Debug.Log(CRyuMgrStaticConstructor.GetInst.mTestScore.ToString());

        // MonoBehaviour를 고려하여 만들어진 것
        Debug.Log(CRyuMgrMono.GetInst.mTestExp.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
