using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[SpaceScript]
[AddComponentMenu("Sinespace/Audio/Audio Reactive Material")]
public class AudioReactiveMaterial : AudioReactiveBaseInternal
{
    [Header("Target Material")]
    public Material Target;

    [Header("Blend Materials")]
    public Material OriginalMaterial;
    public Material TargetMaterial;

    public override void Update()
    {
        base.Update();

        if (Target == null)
        {
            enabled = false;
            return;
        }

        Target.Lerp(OriginalMaterial, TargetMaterial, Power);
    }
}
