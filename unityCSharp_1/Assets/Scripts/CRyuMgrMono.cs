using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrMono : MonoBehaviour
{
    // ���� �� �Ҵ��� ���� �ƴϰ� �����ڿ��� �Ҵ��� �͵� �ƴϹǷ�
    // readonly�� �������� �ʾҴ�
    private static CRyuMgrMono mpInst = null;

    int mTestExp = 888;
    // ������Ƽ
    public static CRyuMgrMono GetInst
    {
        get
        {
            if(mpInst == null)
            {
                // FindObjectOfType<T>
                // �ش� Ŭ���� ��ũ��Ʈ ������Ʈ�� ������ ���� ������Ʈ�� �˻��Ͽ� ã�� ��
                mpInst = FindObjectOfType<CRyuMgrMono>() as CRyuMgrMono;
            }

            return mpInst;
        }
    }

    // ���ӿ�����Ʈ�� �����Ǹ� ���� ���� ȣ��Ǵ� �̺�Ʈ �Լ�
    // MonoBehaviour�� ������ ���� ������ �Ѵٶ�� ���� �ȴ�
    private void Awake()
    {
        if(mpInst == null)
        {
            mpInst = this;
        }
        else if(mpInst != null)
        {
            // Destroy
            // ����Ƽ���� �غ��ص�, ���� ������Ʈ�� �Ҹ��Ű�� �Լ�
            Destroy(this.gameObject);
        }

        // ����Ƽ���� �غ��ص�, ���� ������Ʈ�� ������Ű�� �Լ�(�̸��׸� �����ȯ�ÿ��� �������� �ʰ� ����)
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // �� Ŭ����, GetInstȣ��� ���������
        CRyuMgr.GetInst();

        // �� Ŭ����, ���������ڸ� �̿��Ͽ� mpInst���� �� �Ҵ�Ǿ� ���������
        Debug.Log(CRyuMgrStaticConstructor.GetInst.mTestScore.ToString());

        // MonoBehaviour�� ����Ͽ� ������� ��
        Debug.Log(CRyuMgrMono.GetInst.mTestExp.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
