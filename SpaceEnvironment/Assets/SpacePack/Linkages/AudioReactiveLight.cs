using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[SpaceScript]
[AddComponentMenu("Sinespace/Audio/Audio Reactive Light")]
public class AudioReactiveLight : AudioReactiveBaseInternal
{
    private Light _target;

    public bool Range;
    public float MinRange, MaxRange;

    public bool AnimateColor;
    public Color MinColor, MaxColor;

    public bool Intensity;
    public float MinIntensity, MaxIntensity;

    public override void Update()
    {
        base.Update();

        if (_target == null)
            _target = GetComponent<Light>();

        if (_target == null)
        {
            enabled = false;
            return;
        }

        var power = Power;

        if (Range)
            _target.range = Mathf.Lerp(MinRange, MaxRange, power);

        if (AnimateColor)
            _target.color = Color.Lerp(MinColor, MaxColor, power);

        if (Intensity)
            _target.intensity = Mathf.Lerp(MinIntensity, MaxIntensity, power);
    }
}
