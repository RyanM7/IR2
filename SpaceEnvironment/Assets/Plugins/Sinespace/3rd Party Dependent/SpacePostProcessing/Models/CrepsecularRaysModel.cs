using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.PostProcessing;
//using UnityStandardAssets.ImageEffects;

[Serializable]
public class CrepsecularRaysModel : PostProcessingModel
{
    [Serializable]
    public struct Settings
    {
        public bool AdditiveBlend;

        public Transform SunTransform;
        public int RadialBlurIterations;
        public Color SunColor;
        public Color SunThreshold;
        public float SunShaftBlurRadius;
        public float SunShaftIntensity;

        public float MaxRadius;
        
        public static Settings defaultSettings
        {
            get
            {
                return new Settings
                {
                    AdditiveBlend = false,
                    SunTransform = null,
                    RadialBlurIterations = 2,
                    SunColor = Color.white,
                    SunThreshold = new Color(0.87f,0.74f,0.65f),
                    SunShaftBlurRadius = 2.5f,
                    SunShaftIntensity = 1.15f,
                    MaxRadius = 0.75f,
                };
            }
        }
    }

    [SerializeField] Settings m_Settings = Settings.defaultSettings;

    public Settings settings
    {
        get { return m_Settings; }
        set { m_Settings = value; }
    }

    public override void Reset()
    {
        m_Settings = Settings.defaultSettings;
    }

    public void ApplyUpdates()
    {
        
    }
}
