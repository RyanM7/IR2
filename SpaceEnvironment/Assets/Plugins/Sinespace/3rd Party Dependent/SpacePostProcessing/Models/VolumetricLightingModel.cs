using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.PostProcessing;

[Serializable]
    public class VolumetricLightingModel : PostProcessingModel
    {
    [Serializable]
    public struct Settings
    {
        public static Settings defaultSettings
        {
            get
            {
                return new Settings
                {
                    
                };
            }
        }
    }

    [SerializeField]
    Settings m_Settings = Settings.defaultSettings;
    public Settings settings
    {
        get { return m_Settings; }
        set { m_Settings = value; }
    }

    public override void Reset()
    {
        m_Settings = Settings.defaultSettings;
    }

    private VolumetricLightRenderer _volumeRenderer;

    public void ApplyUpdates()
    {
        if (_volumeRenderer == null)
        {
            _volumeRenderer = Camera.main.GetComponent<VolumetricLightRenderer>();
        }

        if (_volumeRenderer != null)
        {
            _volumeRenderer.enabled = enabled;
        }
    }
}
