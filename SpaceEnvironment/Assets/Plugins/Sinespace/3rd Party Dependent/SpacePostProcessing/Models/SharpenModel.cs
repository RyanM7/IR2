using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.PostProcessing;

[Serializable]
public class SharpenModel : PostProcessingModel
{
    [Serializable]
    public struct Settings
    {
        [Range(0, 10)] public float Amount;

        public static Settings defaultSettings
        {
            get
            {
                return new Settings
                {
                    Amount = 3f
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

    // This needs the Beautify plugin to work. If you have it, feel free to add a || TRUE to these #ifdefs.

#if SPACE_MAIN
    private BeautifyEffect.Beautify _beautify;
#endif

    public void ApplyUpdates()
    {
#if SPACE_MAIN
        if (_beautify == null)
        {
            _beautify = Camera.main.GetComponent<BeautifyEffect.Beautify>();
        }

        if (_beautify != null)
        {
            _beautify.enabled = enabled;
            _beautify.sharpen = settings.Amount;
        }
#endif
    }
}
