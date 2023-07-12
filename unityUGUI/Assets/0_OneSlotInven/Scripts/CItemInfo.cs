using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; // ����ȭ�� ����

/*
    �� Ŭ������ 
    Document-View ���信��

    Document�� �ش��ϴ� Ŭ�����̴�

    � �������� '���� �������� ������ + �ܰ�'���� �����Ѵٸ� 
    �̰��� '���� �������� ������' ��, Document�� �ش��ϴ� �κ��̴�
 



    Serialize�� ����ȭ ��� �����̴�
    ������ �����͸� �ٸ� �����(�̸��׸� ���� �̾߱��ϸ� ��Ʈ��ũ ���� �ٸ� ��ǻ��)�� �״��
    ������ �Ȱ��� �����͸� ����� ���� ���� �̾߱��Ѵ�
    ������ ��������, ����Ʈ ������ �Ϸķ� �þ�� ���� ���·� ����� �����ϹǷ�
    ����ȭ Serialization �̶�� �̸��� �پ���

    MonoBehaviour Ŭ�������� ����ȭ�� ����Ǿ� �ִ�
    �׷��Ƿ� ����Ƽ ������ �󿡼� �ؼ��Ͽ� ������ �� �ʿ��� ���·� ���� �����ϴ�

    �׷��� CItemInfo�� ��Ŭ����(MonoBehaviour�� ��ӹ��� ����)�̹Ƿ� 
    Serialize�� ����Ǿ� ���� �ʴ�

    C#�� �Ӽ�(attribute)������ �̿��Ͽ�
    ��Ŭ������ ����ȭ�� �����ϰڴ�
 */

[Serializable]
public class CItemInfo
{
    public int mId = 0;                // �����۸��� ���� �ĺ���
    public string mName = "";          // ������ �̸�
    public string mImgRscId = "";      // ������ �̹��� �ĺ���



}
