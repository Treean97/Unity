using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EditorWindow ����� ����
using UnityEditor;


/*
    �ش� ��ũ��Ʈ��
    Ȯ�� ������ ������(����Ƽ �����͸� Ȯ���Ű�� ����̴�) ������� �⺻���� ������ ���캸�� �����̴�.

    EditorWindow�� ��ӹ޾�
    ����� ���ǵ� Ȯ�� �����츦 ������

    Ȯ��� ������ �������
    �ݵ�� EditorƯ������ ���� ��ġ�ؾ߸� �۵��Ѵ�
 */

public class CExamEditor : EditorWindow
{
    // �Էµ� ���ڿ� ����
    string mInputString = "";

    // ���� ����
    bool mIsFoldout = false;

    // ����Ƽ���� �����ϴ� �Ӽ��� �̿��Ͽ� �޴� ���
    [MenuItem("CExamEditor/Show CExamEditor")]
    public static void ShowEditor()
    {
        Debug.Log("CExamDeitor.Show");

        // reflection ���� : �����߿� �ش� Ÿ�Կ� ���� ������ ��� ����
        //                  typeof �����߿� �ش� Ÿ�Կ� ���� ������ ��� ������
        EditorWindow.GetWindow(typeof(CExamEditor));

        // ����Ƽ ������ ����
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamEditor.OnEnable");
    }

    private void OnGUI()
    {
        // step_0
        //// Monobehaviour�� OnGUI������ ������� GUI�� ���⼭ ����� �����ϴ�
        //GUI.Label(new Rect(0f, 0f, 240f, 100f), "this is text for test OnGUI");

        //// button
        //if(GUI.Button(new Rect(0f,100f,240f,100f), "TestButton"))
        //{
        //    Debug.Log("click TestButton");
        //}

        //// input textfield
        //mInputString = GUI.TextField(new Rect(0f, 200f, 240f, 100f), mInputString);
        //Debug.Log(mInputString);

        // step_1\
        // ���� ��ġ ���̾ƿ�
        EditorGUILayout.BeginVertical();
        // ���� ��ġ ���̾ƿ�
        // EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("TestButton_GUILayout_0", GUILayout.Width(240f), GUILayout.Height(50f)))
        {
            Debug.Log("Click TestButton_GUILayout_0");
        }

        EditorGUILayout.Space(10f);
        // GUILayout.Space(10f);

        if (GUILayout.Button("TestButton_GUILayout_1", GUILayout.Width(240f), GUILayout.Height(50f)))
        {
            Debug.Log("Click TestButton_GUILayout_1");
        }


        EditorGUILayout.EndVertical();
        // EditorGUILayout.EndHorizontal();

        mIsFoldout = EditorGUILayout.Foldout(mIsFoldout, "TestFoldout");
        if(mIsFoldout)
        {
            EditorGUILayout.BeginVertical();

            //label
            for (int i = 0; i < 5; i++)
            {
                EditorGUILayout.LabelField($"LabelField_{i.ToString()}", EditorStyles.helpBox);
            }

            //button
            if (GUILayout.Button("Button",EditorStyles.miniButton, GUILayout.Width(240f), GUILayout.Height(50f)))
            {
                Debug.Log("Click Button");
            }

            //textfield
            mInputString = EditorGUILayout.TextField(mInputString);

            EditorGUILayout.EndVertical();
        }




    }


}
