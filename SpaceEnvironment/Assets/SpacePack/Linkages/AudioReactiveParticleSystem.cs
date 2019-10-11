using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[SpaceScript]
[AddComponentMenu("Sinespace/Audio/Audio Reactive Particle System")]
public class AudioReactiveParticleSystem : AudioReactiveBaseInternal
{
    private Transform _target;

    public bool Position;
    public Vector3 MinPosition, MaxPosition;

    public bool Rotation;
    public Vector3 MinRotation, MaxRotation;

    public bool Scale;
    public Vector3 MinScale, MaxScale;

    public override void Update()
    {
        base.Update();

        if (_target == null)
            _target = GetComponent<Transform>();

        if (_target == null)
        {
            enabled = false;
            return;
        }

        if (Position)
            _target.localPosition = Vector3.Lerp(MinPosition, MaxPosition, Mathf.Clamp01(Power));

        if (Rotation)
            _target.localRotation = Quaternion.Euler(Vector3.Lerp(MinRotation, MaxRotation, Mathf.Clamp01(Power)));

        if (Scale)
            _target.localScale = Vector3.Lerp(MinScale, MaxScale, Mathf.Clamp01(Power));
    }
}
