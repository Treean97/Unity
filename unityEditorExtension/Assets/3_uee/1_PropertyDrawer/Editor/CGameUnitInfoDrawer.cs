using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/*
    PropertyDrawer�� ������Ʈ�� �ܰ��� �����Ѵ�

    CustomEditor�� ������Ʈ ������ �ܰ� ���� ����� �����ϰ�
    PropertyDrawer�� ������ ����(������Ƽ ����) �ܰ� ������ �����Ѵ�
    �� ���� �ٸ���

 */


// CustomPropertyDrawer �Ӽ� ����, ���� ������ Ŭ������ ¦���� ����� �� PropertyAttributeŸ���� �˷��ش�
[CustomPropertyDrawer(typeof(CGameUnitInfoAttribute))]
// PropertyDrawer ���
public class CGameUnitInfoDrawer : PropertyDrawer  
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        // ���� �鿩���� �ɼ��� ������ش�
        var indent = EditorGUI.indentLevel;

        // �鿩���� ���� ����
        EditorGUI.indentLevel = 0;

        // ���� ����
        var amountRect = new Rect(position.x, position.y, 60f, position.height - 50f);
        var unitRect = new Rect(position.x + 65f, position.y, 30f, position.height - 50f);
        var nameRect = new Rect(position.x + 100f, position.y, position.width - 100f, position.height - 50f);

        var tBtnRect = new Rect(position.x, position.y + 20, position.width, position.height - 20f);

        // field UI ����
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("mName"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("mLevel"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("mTypeJob"), GUIContent.none);


        // ���� �鿩���� �ɼ����� ������
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();

        if(GUI.Button(tBtnRect, "Test Button"))
        {
            // ������Ƽ�� �̿��Ͽ� �ش� �����鿡 ���� ��� ��
            Debug.Log(property.FindPropertyRelative("mName").stringValue.ToString());
            Debug.Log(property.FindPropertyRelative("mLevel").intValue.ToString());
            Debug.Log(property.FindPropertyRelative("mTypeJob").enumValueIndex.ToString());

            // ������Ƽ�� �̿��Ͽ� �ش� �������� ���� �����ϴ� ��
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
