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
    // N개의 대사들을 관리하는 자료구조
    List<CDialogueInfo> mDialogueInfos = null;
    int mCurCount = 0;

    [MenuItem("CExamTool/Show CExamTool")]
    public static void ShowEditor()
    {
        Debug.Log("CExamDeitor.Show");

        // reflection 문법 : 실행중에 해당 타입에 대한 정보를 얻는 문법
        //                  typeof 실행중에 해당 타입에 대한 정보를 얻는 연산자
        EditorWindow.GetWindow(typeof(CExamTool));

        // 유니티 에디터 갱신
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamTool.OnEnable");

        // 자료구조 생성
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

        // 대사 추가 메뉴
        if (GUILayout.Button("Add Dialogue", GUILayout.Width(100f), GUILayout.Height(50f))) 
        {

            // 새로운 대사 정보
            CDialogueInfo tInfo = new CDialogueInfo();

            // 새로운 대사 카운트용 변수
            tInfo.mId = mCurCount;
            tInfo.mName = "말하는 사람";
            tInfo.mDialogue = $"{mCurCount.ToString()}번째 대화입니다.";

            mDialogueInfos.Add(tInfo);
            mCurCount++;
        }

        GUILayout.Space(5f);

        if(GUILayout.Button("New", GUILayout.Width(100f), GUILayout.Height(50f)))
        {
            // 메모리에 있는 대사정보 모두 제거
            for(int i = 0; i < mDialogueInfos.Count; i++)
            {
                mDialogueInfos[i] = null;
            }

            mDialogueInfos.Clear();

            mCurCount = 0;

            // 유니티 에디터 갱신
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
            // 이 Tool에서는 파일을 만들어 저장할 것이다
            // 파일 개념으로 다룰 것이기 때문에 경로를 다 명시하였고
            // 확장자도 명시했다
            SaveToFile("Assets/Resources/dialogue_list.xml");

            // 에셋데이터베이스 갱신
            AssetDatabase.Refresh();
            // 유니티는 에셋 정보들을 관리하는 데이터베이스 개념을 가지고 있다
            // Library폴더에 ArtifactDB, SoruceAssetDB가 그 주요한 데이터들이다
            // 이 두가지를 관리하는 주체가 되는 클래스가 AssetDatabase이다

            // 여기서는 파일을 새로 만들어 Assets폴더에 두었으므로
            // 파일이 임포트되어 에셋화가 되었다고 가정한다
            // 그래서 에셋 데이터베이스를 갱신해주었다

            // 유니티 에디터 갱신
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
            // 파일이 존재하지 않으면 로드 실패
            Debug.Log("Load Fail");

            return;
        }

        // 파일이 존재한다
        XmlDocument tDoc = new XmlDocument();
        tDoc.Load(tFileName);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];

        int ti = 0;     // 카운트용 변수
        int tCount = tElementRoot.ChildNodes.Count;  // 총 대사 갯수

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

    // 대사 정보를 xml 파일로 저장
    void SaveToFile(string tFileName)
    {
        StreamWriter tStreamWriter = null;

        FileInfo tFileInfo = new FileInfo(tFileName);

        if(tFileInfo.Exists)
        {
            // 파일이 존재하면, 지우고 새로 만든다
            tFileInfo.Delete();
            tStreamWriter = tFileInfo.CreateText();
        }
        else
        {
            // 파일이 존재하지 않으면, 새로 만든다
            tStreamWriter = tFileInfo.CreateText();
        }

        tStreamWriter.Close();

        // Xml형태로 저장한다
        XmlDocument tDoc = new XmlDocument();   // Xml문서 객체
        XmlElement tElementRoot = tDoc.CreateElement("DialogueInfoList");   // 루트노드 생성
        tDoc.AppendChild(tElementRoot);     // 문서에 루트노드 추가

        int ti = 0;     // 카운트용 변수
        int tCount = mDialogueInfos.Count;  // 총 대사 갯수

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;

        for (ti = 0; ti < tCount; ti++)
        {
            tInfo = mDialogueInfos[ti];
            XmlElement tElement = tDoc.CreateElement("DialogueInfo");

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mId"); // 태그
            tElement_0.InnerText = tInfo.mId.ToString();
            tElement.AppendChild(tElement_0);

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mName"); // 태그
            tElement_0.InnerText = tInfo.mName;
            tElement.AppendChild(tElement_0);

            tElement_0 = null;
            tElement_0 = tDoc.CreateElement("mDialogue"); // 태그
            tElement_0.InnerText = tInfo.mDialogue;
            tElement.AppendChild(tElement_0);

            tElementRoot.AppendChild(tElement);
        }

        tDoc.Save(tFileName);   //XmlDocument의 기능을 이용하여 파일로 저장
    }
}
