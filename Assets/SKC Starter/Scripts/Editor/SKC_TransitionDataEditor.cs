/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SKC_TransitionData))]
[CanEditMultipleObjects]
public class SKC_TransitionDataEditor : Editor
{
    SerializedProperty transitionType,axisType,tweenType,oneImageTransition,secondImageTransition,
        timeBetweenTransition,finishXpos, finishYpos,alpha, finishXpos2, finishYpos2,hasAlpha;

    private void OnEnable()
    {
        SKC_TransitionData myTransitionSc = (SKC_TransitionData)target;

        transitionType = serializedObject.FindProperty("transitionType");
        axisType = serializedObject.FindProperty("axisType");
        tweenType = serializedObject.FindProperty("tweenType");
        oneImageTransition = serializedObject.FindProperty("oneImageTransition");
        secondImageTransition = serializedObject.FindProperty("secondImageTransition");
        timeBetweenTransition = serializedObject.FindProperty("timeBetweenTransition");
        finishXpos = serializedObject.FindProperty("finishXpos");
        finishYpos = serializedObject.FindProperty("finishYpos");
        finishXpos2 = serializedObject.FindProperty("finishXpos2");
        finishYpos2 = serializedObject.FindProperty("finishYpos2");
        alpha = serializedObject.FindProperty("alpha");
        hasAlpha = serializedObject.FindProperty("hasAlpha");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(transitionType);
        if(transitionType.intValue == 0)
        {
            EditorGUILayout.PropertyField(axisType);
            EditorGUILayout.Space(4);
            if (axisType.intValue == 0)
            {
                EditorGUILayout.PropertyField(finishXpos);
            }
            if (axisType.intValue == 1)
            {
                EditorGUILayout.PropertyField(finishYpos);
            }
            if (axisType.intValue == 2)
            {
                EditorGUILayout.PropertyField(finishXpos);
                EditorGUILayout.Space(2);
                EditorGUILayout.PropertyField(finishYpos);
            }
            EditorGUILayout.PropertyField(oneImageTransition);
            EditorGUILayout.PropertyField(timeBetweenTransition);
            EditorGUILayout.PropertyField(hasAlpha);
            if (hasAlpha.boolValue) EditorGUILayout.PropertyField(alpha);
            EditorGUILayout.Space(4);
            EditorGUILayout.PropertyField(tweenType);
        }
        if (transitionType.intValue == 1)
        {
            EditorGUILayout.PropertyField(axisType);
            EditorGUILayout.Space(4);
            if (axisType.intValue == 0)
            {
                EditorGUILayout.PropertyField(finishXpos);
                EditorGUILayout.Space(2);
                EditorGUILayout.PropertyField(finishXpos2);
            }
            if (axisType.intValue == 1)
            {
                EditorGUILayout.PropertyField(finishYpos);
                EditorGUILayout.Space(2);
                EditorGUILayout.PropertyField(finishYpos2);
            }
            if (axisType.intValue == 2)
            {
                EditorGUILayout.PropertyField(finishXpos);
                EditorGUILayout.Space(2);
                EditorGUILayout.PropertyField(finishYpos);
                EditorGUILayout.Space(4);
                EditorGUILayout.PropertyField(finishXpos2);
                EditorGUILayout.Space(2);
                EditorGUILayout.PropertyField(finishYpos2);
            }
            EditorGUILayout.PropertyField(oneImageTransition);
            EditorGUILayout.PropertyField(secondImageTransition);
            EditorGUILayout.PropertyField(timeBetweenTransition);
            EditorGUILayout.PropertyField(hasAlpha);
            if (hasAlpha.boolValue) EditorGUILayout.PropertyField(alpha);
            EditorGUILayout.Space(4);
            EditorGUILayout.PropertyField(tweenType);
        }

        serializedObject.ApplyModifiedProperties();
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */