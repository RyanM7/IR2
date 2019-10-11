using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.PostProcessing;

[PostProcessingModelEditor(typeof(VolumetricLightingModel))]
public class VolumetricLightingModelEditor : PostProcessingModelEditor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("This effect can only be enabled/disabled.");
    }
}