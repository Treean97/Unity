using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    기즈모 : 게임 제작 시 사용하는(시각적, 조작적인 도움을 주는) 부가적인 물체
    시각적 디버깅을 씬 뷰에서 할 수 있게 해주는 부가적인 도구이다


 */

public class testGizmo_0 : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // 노랑
        Gizmos.color = new Color(1f, 1f, 0f, 1f);

        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.2f);
        // localScale : 로컬좌표계 상의 스케일
        // lossyScale : 절대좌표계 상의 스케일

        // 8비트로 한 성분을 나타낸다, [0,255]
        //Gizmos.color = new Color32(0, 255, 255, 255);   
        //Gizmos.DrawWireSphere(this.transform.position, Mathf.Sqrt(2) / 2);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
