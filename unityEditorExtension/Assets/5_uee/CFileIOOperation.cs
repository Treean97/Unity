using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    고전적인 렌더링에서의 셰이더
    : 상황에 따른 재질을 case by case로 모두 만드는 방식

    물리기반 셰이더
    : 다양한 재질을 임의의 몇개의 수학적 모델로 표헌하여 렌더링하는 방법
    물리적으로 측정된 수치들에 기반한다는 특징도 있다

    물리기반 렌더링의 셰이더
    : 물리기반 렌더링에서 사용되는 셰이더


    Diffuse 확산광, 난반사광
    : 램버트 조명 모델은 난반사광 모델이다
    빛이 난반사되는 것을 모델로 만든 것
    유니티의 물리기반 셰이더에서는 albedo가 이에 대응된다
    
    Specular 정반사광
    : 고전적인 셰이더에서 이야기하는 용어
    빛이 정반사 되는 것을 모델로 만든 것

 */


#if UNITY_EDITOR
using UnityEditor;


public class CFileIOOperation 
{
    [MenuItem("AssetDatabase/FileOperation", false, 1)]
    
    static void FileOperation()
    {
        // step_0 머테리얼 에셋 생성
        //Material tMaterial = new Material(Shader.Find("Standard"));
        //Material tMaterial = new Material(Shader.Find("Specular"));
        //AssetDatabase.CreateAsset(tMaterial, "Assets/0_MyMaterial.mat");


        // step_1 Rename
        //AssetDatabase.RenameAsset("Assets/0_MyMaterial.mat", "0_MatSpecular");


        // step_2 폴더 에셋 생성
        //AssetDatabase.CreateFolder("Assets", "5_uee_NewFolder");


        // step_3 Move Asset
        //AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(tMaterial), "Assets/5_uee_NewFolder/0_MatSpecular.mat");


        // step_3 Delete Asset
        //AssetDatabase.DeleteAsset("Assets/5_uee_NewFolder/0_MatSpecular.mat");
        //AssetDatabase.DeleteAsset("Assets/0_MyMaterial.mat");


        // step_4 Delete Folder
        // 폴더도 에셋
        //AssetDatabase.DeleteAsset("Assets/5_uee_NewFolder");


        // 에셋데이터베이스 갱신
        AssetDatabase.Refresh();

    }
}


#endif