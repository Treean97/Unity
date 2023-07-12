using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CModifyAsset 
{
    [MenuItem("AssetDatabase/Create AnimationClip", false, 12)]
    static void DoCreateAnimationClip()
    {
        var t = new AnimationClip();

        AssetDatabase.CreateAsset(t, "Assets/New AnimationClip.anim");
    }

    [MenuItem("AssetDatabase/Change AnimationClip FrameRate", false, 13)]
    static void DoChangeAnimationClipFrameRate()
    {
        var t = AssetDatabase.LoadAssetAtPath<AnimationClip>("AssetsItem/new AnimationClip.anim");

        t.frameRate++;

        // ��ũ�� ���� ���·� �������� ����
        AssetDatabase.SaveAssets();
    }
}
