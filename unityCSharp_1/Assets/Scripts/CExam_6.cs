using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    ���

    const vs readonly

    ������ Ÿ�� ���
        const ������ �����
        ������ ������ ����� ��ü�ȴ�    

    ��) ����� ������, enum, null, ���ڿ�(""�� ����� ��)

    ��Ÿ�� ���
        readonly ������ �����
        
        1. ��Ÿ�� �����ڿ��� �ʱ�ȭ�� ����
            ������ Ÿ�� ����� ������ �ÿ� ��� ������ ��ü�ǹǷ� �׷� �� ����. ������ �� �ʱ�ȭ ǥ���� ����
        2. � Ÿ�԰��� ��� �����ϴ�
            ������ Ÿ�� ����� �����Ͻÿ� ���� �����Ǿ�� �ϹǷ� �̸� ������� ������ �� �ִ� Ÿ���� ��쿡�� �����ϴ�
        3. �ν��Ͻ����� �ٸ� ���� ���� ���� �ִ�
            �����ڿ��� ��쿡 ���� �ٸ��� �Է¹޾� �ʱ�ȭ�� ����, �� ���Ŀ��� �����Ұ�


 */


public class CExam_6 : MonoBehaviour
{
    // ������ Ÿ�� ��� const ����� ���
    public const int mConstInt = 777;

    // ��Ÿ�� ��� readonly ����� ���
    public readonly int mReadOnlyInt = 999;

    CExam_6(int tReadonlyInt)
    {
        // mConstInt = tReadonlyInt; // ������ ����� �ȵ�
        mReadOnlyInt = tReadonlyInt; // ��Ÿ�� ����� �����ڿ��� �ʱ�ȭ ����

    }

    // Start is called before the first frame update
    void Start()
    {
        // mConstInt = 7; �ȵ�
        Debug.Log($"const {mConstInt.ToString()}"); ;

        // mReadOnlyInt = 9; �ȵ�
        Debug.Log($"readonly {mReadOnlyInt.ToString()}"); ;

        // ������ Ÿ�� ����� ������ �޼ҵ�(�Լ�) �ȿ��� ���� ����
        const float tGravity = 9.8f;
        // ��Ÿ�� ����� ������ �޼ҵ� �ȿ��� ���� �Ұ�
        // readonly float tGRAVITY = 9.8f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
