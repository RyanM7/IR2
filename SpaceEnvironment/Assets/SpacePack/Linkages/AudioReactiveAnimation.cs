using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[SpaceScript]
[AddComponentMenu("Sinespace/Audio/Audio Reactive Animation")]
public class AudioReactiveAnimation : AudioReactiveBaseInternal
{
    private Animator _target;
    public string Parameter;

    public override void Update()
    {
        base.Update();

        if (_target == null)
            _target = GetComponent<Animator>();

        if (_target == null)
        {
            enabled = false;
            return;
        }

        if (!string.IsNullOrEmpty(Parameter))
            _target.SetFloat(Parameter, Power);
        else
            _target.SetFloat("Audio", Power);
    }
}
