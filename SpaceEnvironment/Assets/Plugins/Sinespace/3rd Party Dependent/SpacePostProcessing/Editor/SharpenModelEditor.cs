using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.PostProcessing;
using UnityEngine;
using UnityEngine.PostProcessing;

[PostProcessingModelEditor(typeof(SharpenModel))]
public class SharpenModelEditor : PostProcessingModelEditor
{
    SerializedProperty m_Amount;
    
    public override void OnEnable()
    {
        m_Amount = FindSetting((SharpenModel.Settings x) => x.Amount);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(m_Amount);
    }
}
