using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EditorWindow 사용을 위함
using UnityEditor;


/*
    해당 스크립트는
    확장 에디터 윈도우(유니티 에디터를 확장시키는 기능이다) 만들기의 기본적인 구성을 살펴보기 위함이다.

    EditorWindow를 상속받아
    사용자 정의된 확장 윈도우를 만들자

    확장된 에디터 윈도우는
    반드시 Editor특수폴더 내에 위치해야만 작동한다
 */

public class CExamEditor : EditorWindow
{
    // 입력된 문자열 변수
    string mInputString = "";

    // 접힘 여부
    bool mIsFoldout = false;

    // 유니티에서 제공하는 속성을 이용하여 메뉴 등록
    [MenuItem("CExamEditor/Show CExamEditor")]
    public static void ShowEditor()
    {
        Debug.Log("CExamDeitor.Show");

        // reflection 문법 : 실행중에 해당 타입에 대한 정보를 얻는 문법
        //                  typeof 실행중에 해당 타입에 대한 정보를 얻는 연산자
        EditorWindow.GetWindow(typeof(CExamEditor));

        // 유니티 에디터 갱신
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamEditor.OnEnable");
    }

    private void OnGUI()
    {
        // step_0
        //// Monobehaviour의 OnGUI용으로 만들어진 GUI도 여기서 사용이 가능하다
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
        // 세로 배치 레이아웃
        EditorGUILayout.BeginVertical();
        // 가로 배치 레이아웃
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
