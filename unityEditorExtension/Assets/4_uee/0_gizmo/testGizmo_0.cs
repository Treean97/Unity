using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ����� : ���� ���� �� ����ϴ�(�ð���, �������� ������ �ִ�) �ΰ����� ��ü
    �ð��� ������� �� �信�� �� �� �ְ� ���ִ� �ΰ����� �����̴�


 */

public class testGizmo_0 : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // ���
        Gizmos.color = new Color(1f, 1f, 0f, 1f);

        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.2f);
        // localScale : ������ǥ�� ���� ������
        // lossyScale : ������ǥ�� ���� ������

        // 8��Ʈ�� �� ������ ��Ÿ����, [0,255]
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
