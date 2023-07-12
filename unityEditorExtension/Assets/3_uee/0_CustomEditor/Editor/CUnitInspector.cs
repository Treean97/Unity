using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    ����Ƽ ������ Ȯ�� ��� �߿���
    �ν����Ϳ� ǥ�õǴ�
    ������Ʈ�� �ܰ��� ��������ִ� ����� �����Ѵ�

    �� �߿� �ϳ��� CustomEditor�̴�

    �̰��� ������Ʈ ������ ����ȴ�
 */

[CustomEditor(typeof(CUnit))] // CustomEditor�Ӽ�, Ÿ�� Ÿ���� �˷��ش�
public class CUnitInspector : Editor    // ���
{
    // Ÿ�� Ÿ�Կ� ���� ������ �ϳ� ����
    CUnit mpUnit = null;    

    private void OnEnable()
    {
        // Ÿ���� ��´�
        mpUnit = this.target as CUnit;  
    }

    // �ν����Ϳ� ǥ�õǴ� ������Ʈ�� �ܰ��� �� �̺�Ʈ �Լ��� Ŀ���͸���¡�Ѵ�
    public override void OnInspectorGUI()   
    {
        // ����ȭ ����� ����
        serializedObject.Update();

        // �θ�Ŭ����Editor�� OnInspectorGUI�� ȣ��
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("AP", mpUnit.mAP.ToString());

        if(GUILayout.Button("Random mEndurance"))
        {
            mpUnit.mEndurance = Random.Range(0, 99);
        }

        if (GUILayout.Button("Random mStr"))
        {
            mpUnit.mStr = Random.Range(0, 9);
        }


        // ����ȭ ����� �̿��Ͽ� ����� �ܰ��� ����
        serializedObject.ApplyModifiedProperties();
        
    }

    // ������ ǥ�ø� ���� �غ�� �̺�Ʈ �Լ�
    public override bool HasPreviewGUI()
    {
        // return base.HasPreviewGUI();
        // true : ������ ǥ�� ����
        return true;
    }

    public override GUIContent GetPreviewTitle()
    {
        // return base.GetPreviewTitle();
        return new GUIContent("unit stats");
    }


    public override void OnPreviewSettings()
    {
        base.OnPreviewSettings();

        // UI�� ��Ÿ�� ����
        //GUIStyle tPreLabel = new GUIStyle("preview label");
        //GUIStyle tPreButton = new GUIStyle("preview button");

        // UI����
        GUILayout.Label("Label test", GUIStyle.none);
        GUILayout.Button("Button test", GUIStyle.none);
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);

        GUI.Box(r, "AP�������� :\nmBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16)");
    }

}

