using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MonoBehaviour�� ��ӹ��� Ŭ������ 
    Editor ������ ��ġ�ϸ� ����� �۵����� �ʴ´�.(���ӿ�����Ʈ�� ��ũ��Ʈ ������Ʈ�� ���Ұ�)


 
 */

#if UNITY_EDITOR
using UnityEditor;
#endif

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //MonoBehaviour�� ��ӹ��� NewBehaviourScript�� Editor���� �ٱ��� ������
        //Editor ���� ���ʿ� ��ġ�� ExamEditorWindow�� �� �� ����
#if UNITY_EDITOR
        EditorWindow.GetWindow<ExamEditorWindow>(true);
#endif

        // dll�� C#���� �߰��ܰ� ������� Ȯ�����̴�(�����)
        // ���� �ÿ� �����Ǵ� Assembly-CSharp.dll������ UnityEditor.dll���� ������ �߻����� �ʱ� ������ ���� ������ �߻�

        /*
            ���� ��������� ����Ƽ ������ Ȯ�� �����찡 ���ԵǸ� �ȵ�
            Assembly-CSharp.dll

            ����Ƽ ������ Ȯ���� ���� �κп��� ���Ӿ��� ����(MonoBehaviour ��) ����� ���ԵǸ� �ȵ�
            UnityEditor.dll

            ��, �߰� ������� ������ �ٸ�
         */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
