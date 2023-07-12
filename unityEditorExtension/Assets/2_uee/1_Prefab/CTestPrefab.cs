using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CTestPrefab : MonoBehaviour
{
    public int mTest = 0;

    // ���Ǻ� �����Ϸ�
    // ����Ƽ ������ �󿡼���� �� �ڵ� ������ �������Ѵ�
#if UNITY_EDITOR
    [MenuItem("TestMenu/make CTestPrefab")]
    static void CreateTestPrefab()
    {
        // �������� ��ũ��Ʈ�� ������
        // �޸�
        // �������� ����
        GameObject tParent = new GameObject("PFTestPrefab");
        GameObject tChild = new GameObject("instBody");
        tChild.transform.SetParent(tParent.transform);

        // ������Ʈ ����
        tParent.AddComponent(typeof(CTestPrefab));
        tParent.AddComponent(typeof(Rigidbody));

        // ��ũ
        // ������ ����(����)�� ����
        PrefabUtility.SaveAsPrefabAsset(tParent, "Assets/Resources/PFTestPrefab.prefab");

        // ���� �����ͺ��̽� ����
        AssetDatabase.Refresh();
    }

#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
