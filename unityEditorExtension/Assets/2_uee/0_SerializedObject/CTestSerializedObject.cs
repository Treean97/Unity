using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ����Ƽ �󿡼� �ٷ�� ��� Object���� SerializedObject�� ������� �Ѵ�
// (����ȭ ����� ������ ������Ʈ)

/*
    SerializedObject�� ����Ƽ���� �����ϴ� ������Ʈ�μ�
    Serialize ����� �����ϴ� Ŭ�����̴�.
    
    ����Ƽ �󿡼� �ٷ�� ������Ʈ���� ��� SerializedObject�� ������� �Ѵ�.
    ��, ����Ƽ �󿡼� �ٷ�� ������Ʈ���� ��� Serialize ����� �ִ�.

    ����Ƽ�� ���ҽ� ������ ��Ī�ϴ� Asset�� ����������
    �̹��� ������ import �Ͽ� ����ȭ�ϸ�
    �ش� ���¿����� �̷��� Ư¡�� ������ �� �ִ�.

    meta���Ͽ��� Asset�� �ΰ����� �������� ����ϰ� �ִ�.
    �޸� �� ����(������Ʈ�� ����)�� ��ũ �� �������ϰ� meta���Ϸ� �����ǰ� �ȴ�

 */


public class CTestSerializedObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �Ͼ�� �⺻ �ؽ�ó�� SerializedObject�� ����
        var tSO = new SerializedObject(Texture2D.whiteTexture);

        var tPop = tSO.GetIterator();

        while(tPop.NextVisible(true))
        {
            Debug.Log(tPop.propertyPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
