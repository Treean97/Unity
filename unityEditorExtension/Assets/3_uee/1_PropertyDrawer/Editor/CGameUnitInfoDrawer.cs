using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/*
    PropertyDrawer는 컴포넌트의 외관을 변경한다

    CustomEditor는 컴포넌트 단위로 외관 변경 기능을 수행하고
    PropertyDrawer는 데이터 별로(프로퍼티 별로) 외관 변경을 수행한다
    는 점이 다르다

 */


// CustomPropertyDrawer 속성 적용, 원래 데이터 클래스에 짝으로 만들어 둔 PropertyAttribute타입을 알려준다
[CustomPropertyDrawer(typeof(CGameUnitInfoAttribute))]
// PropertyDrawer 상속
public class CGameUnitInfoDrawer : PropertyDrawer  
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        // 기존 들여쓰기 옵션을 기억해준다
        var indent = EditorGUI.indentLevel;

        // 들여쓰기 레벨 설정
        EditorGUI.indentLevel = 0;

        // 영역 결정
        var amountRect = new Rect(position.x, position.y, 60f, position.height - 50f);
        var unitRect = new Rect(position.x + 65f, position.y, 30f, position.height - 50f);
        var nameRect = new Rect(position.x + 100f, position.y, position.width - 100f, position.height - 50f);

        var tBtnRect = new Rect(position.x, position.y + 20, position.width, position.height - 20f);

        // field UI 설정
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("mName"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("mLevel"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("mTypeJob"), GUIContent.none);


        // 기존 들여쓰기 옵션으로 돌린다
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();

        if(GUI.Button(tBtnRect, "Test Button"))
        {
            // 프로퍼티를 이용하여 해당 변수들에 값을 얻는 예
            Debug.Log(property.FindPropertyRelative("mName").stringValue.ToString());
            Debug.Log(property.FindPropertyRelative("mLevel").intValue.ToString());
            Debug.Log(property.FindPropertyRelative("mTypeJob").enumValueIndex.ToString());

            // 프로퍼티를 이용하여 해당 변수들의 값을 설정하는 예
            property.FindPropertyRelative("mName").stringValue = "superman";
            property.FindPropertyRelative("mLevel").intValue = 99;
            property.FindPropertyRelative("mTypeJob").intValue = (int)TYPE_JOB.JOB_ARCHOR;

        }



    }

    float mSomeAdditionalHeight = 50.0f;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        return base.GetPropertyHeight(property, label) + mSomeAdditionalHeight;
    }

}
