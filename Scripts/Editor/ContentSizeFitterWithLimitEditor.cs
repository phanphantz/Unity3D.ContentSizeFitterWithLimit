using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ContentSizeFitterWithLimit))]
public class ContentSizeFitterWithLimitEditor : Editor
{
    ContentSizeFitterWithLimit contentFitter;

    void Prepare()
    {
        contentFitter = (ContentSizeFitterWithLimit)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Prepare();

        EditorGUI.BeginChangeCheck();
        var limitWidth = EditorGUILayout.Toggle("Limit Width", contentFitter.LimitWidth);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(contentFitter, "Modify ContentSizeFitterWithLimit");
            contentFitter.LimitWidth = limitWidth;
        }

        if (limitWidth)
        {
            EditorGUI.indentLevel++;

            EditorGUI.BeginChangeCheck();
            var maxWidth = EditorGUILayout.FloatField("Max Width", contentFitter.MaxWidth);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(contentFitter, "Modify ContentSizeFitterWithLimit");
                contentFitter.MaxWidth = maxWidth;
            }

            EditorGUI.indentLevel--;
        }

        EditorGUI.BeginChangeCheck();
        var limitHeight = EditorGUILayout.Toggle("Limit Height", contentFitter.LimitHeight);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(contentFitter, "Modify ContentSizeFitterWithLimit");
            contentFitter.LimitHeight = limitHeight;
        }

        if (limitHeight)
        {
            EditorGUI.indentLevel++;

            EditorGUI.BeginChangeCheck();
            var maxHeight = EditorGUILayout.FloatField("Max Height", contentFitter.MaxHeight);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(contentFitter, "Modify ContentSizeFitterWithLimit");
                contentFitter.MaxHeight = maxHeight;
            }

            EditorGUI.indentLevel--;
        }

    }
}
