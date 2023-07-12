using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Xml;
using UnityEditor.VersionControl;

public class CExamTool : EditorWindow
{
    // N���� ������ �����ϴ� �ڷᱸ��
    List<CDialogueInfo> mDialogueInfos = null;
    int mCurCount = 0;

    [MenuItem("CExamTool/Show CExamTool")]
    public static void ShowEditor()
    {
        Debug.Log("CExamDeitor.Show");

        // reflection ���� : �����߿� �ش� Ÿ�Կ� ���� ������ ��� ����
        //                  typeof �����߿� �ش� Ÿ�Կ� ���� ������ ��� ������
        EditorWindow.GetWindow(typeof(CExamTool));

        // ����Ƽ ������ ����
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamTool.OnEnable");

        // �ڷᱸ�� ����
        if (mDialogueInfos == null)
        {
            mDialogueInfos = new List<CDialogueInfo>();
        }
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("edit..", EditorStyles.helpBox);

        EditorGUILayout.BeginHorizontal();

        // ��� �߰� �޴�
        if (GUILayout.Button("Add Dialogue", GUILayout.Width(100f), GUILayout.Height(50f))) 
        {

            // ���ο� ��� ����
            CDialogueInfo tInfo = new CDialogueInfo();

            // ���ο� ��� ī��Ʈ�� ����
            tInfo.mId = mCurCount;
            tInfo.mName = "���ϴ� ���";
            tInfo.mDialogue = $"{mCurCount.ToString()}��° ��ȭ�Դϴ�.";

            mDialogueInfos.Add(tInfo);
            mCurCount++;
        }

        GUILayout.Space(5f);

        if(GUILayout.Button("New", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            // �޸𸮿� �ִ� ������� ��� ����
            for(int i = 0; i < mDialogueInfos.Count; i++)
            {
                mDialogueInfos[i] = null;
            }

            mDialogueInfos.Clear();

            mCurCount = 0;

            // ����Ƽ ������ ����
            EditorApplication.update();

        }

        EditorGUILayout.EndHorizontal();

        GUILayout.Space(5f);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Load", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            LoadFromFile("Assets/Resources/dialogue_list.xml");
        }

        GUILayout.Space(5f);

        if (GUILayout.Button("Save", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            // �� Tool������ ������ ����� ������ ���̴�
            // ���� �������� �ٷ� ���̱� ������ ��θ� �� ����Ͽ���
            // Ȯ���ڵ� ����ߴ�
            SaveToFile("Assets/Resources/dialogue_list.xml");

            // ���µ����ͺ��̽� ����
            AssetDatabase.Refresh();
            // ����Ƽ�� ���� �������� �����ϴ� �����ͺ��̽� ������ ������ �ִ�
            // Library������ ArtifactDB, SoruceAssetDB�� �� �ֿ��� �����͵��̴�
            // �� �ΰ����� �����ϴ� ��ü�� �Ǵ� Ŭ������ AssetDatabase�̴�

            // ���⼭�� ������ ���� ����� Assets������ �ξ����Ƿ�
            // ������ ����Ʈ�Ǿ� ����ȭ�� �Ǿ��ٰ� �����Ѵ�
            // �׷��� ���� �����ͺ��̽��� �������־���

            // ����Ƽ ������ ����
            EditorApplication.update();
        }

        EditorGUILayout.EndHorizontal();

        for (int i = 0; i < mDialogueInfos.Count; i++)
        {
            // display id
            EditorGUILayout.LabelField(mDialogueInfos[i].mId.ToString(), EditorStyles.helpBox);

            //display and edit name 
            mDialogueInfos[i].mName = EditorGUILayout.TextField(mDialogueInfos[i].mName);

            //display and edit dialogue 
            mDialogueInfos[i].mDialogue = EditorGUILayout.TextField(mDialogueInfos[i].mDialogue);
            }

        EditorGUILayout.EndVertical();
    }


    void LoadFromFile(string tFileName)
    {
        FileInfo tFileInfo = new FileInfo(tFileName);
        if(false == tFileInfo.Exists)
        {
            // ������ �������� ������ �ε� ����
            Debug.Log("Load Fail");

            return;
        }

        // ������ �����Ѵ�
        XmlDocument tDoc = new XmlDocument();
        tDoc.Load(tFileName);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];

        int ti = 0;     // ī��Ʈ�� ����
        int tCount = tElementRoot.ChildNodes.Count;  // �� ��� ����

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;

        for(ti = 0; ti < tCount; ti++)
        {
            tElement_0 = tElementRoot.ChildNodes[ti] as XmlElement;

            tInfo = new CDialogueInfo();

            tInfo.mId = Convert.ToInt32(tElement_0.ChildNodes[0].InnerText);
            tInfo.mName = tElement_0.ChildNodes[1].InnerText;
            tInfo.mDialogue = tElement_0.ChildNodes[2].InnerText;

            mDialogueInfos.Add(tInfo);
        }


    }

    // ��� ������ xml ���Ϸ� ����
    void SaveToFile(string tFileName)
    {
        StreamWriter tStreamWriter = null;

        FileInfo tFileInfo = new FileInfo(tFileName);

        if(tFileInfo.Exists)
        {
            // ������ �����ϸ�, ����� ���� �����
            tFileInfo.Delete();
            tStreamWriter = tFileInfo.CreateText();
        }
        else
        {
            // ������ �������� ������, ���� �����
            tStreamWriter = tFileInfo.CreateText();
        }

        tStreamWriter.Close();

        // Xml���·� �����Ѵ�
        XmlDocument tDoc = new XmlDocument();   // Xml���� ��ü
        XmlElement tElementRoot = tDoc.CreateElement("DialogueInfoList");   // ��Ʈ��� ����
        tDoc.AppendChild(tElementRoot);     // ������ ��Ʈ��� �߰�

        int ti = 0;     // ī��Ʈ�� ����
        int tCount = mDialogueInfos.Count;  // �� ��� ����

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;

        for (ti = 0; ti < tCount; ti++)
        {
            tInfo = mDialogueInfos[ti];
            XmlElement tElement = tDoc.CreateElement("DialogueInfo");

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mId"); // �±�
            tElement_0.InnerText = tInfo.mId.ToString();
            tElement.AppendChild(tElement_0);

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mName"); // �±�
            tElement_0.InnerText = tInfo.mName;
            tElement.AppendChild(tElement_0);

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mDialogue"); // �±�
            tElement_0.InnerText = tInfo.mDialogue;
            tElement.AppendChild(tElement_0);

            tElementRoot.AppendChild(tElement);
        }

        tDoc.Save(tFileName);   //XmlDocument�� ����� �̿��Ͽ� ���Ϸ� ����
    }
}
