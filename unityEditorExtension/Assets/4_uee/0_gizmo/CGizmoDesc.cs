using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CGizmoDesc
{
#if UNITY_EDITOR
    [DrawGizmo(GizmoType.NonSelected)]
    static void DrawgizmosNonSelected(testGizmo_1 t, GizmoType tGizmoType)
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireCube(t.transform.position, t.transform.lossyScale * 1.2f);
    }

    [DrawGizmo(GizmoType.InSelectionHierarchy)]
    static void DrawgizmosSelected(testGizmo_1 t, GizmoType tGizmoType)
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireCube(t.transform.position, t.transform.lossyScale * 1.1f);
    }
#endif
}
