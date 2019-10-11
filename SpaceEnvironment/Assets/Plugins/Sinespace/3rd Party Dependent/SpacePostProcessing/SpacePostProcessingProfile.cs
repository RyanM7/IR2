using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.PostProcessing;

public class SpacePostProcessingProfile : PostProcessingProfile
{
    public SharpenModel Sharpen = new SharpenModel();
    public CrepsecularRaysModel CrepsecularRays = new CrepsecularRaysModel();
    public VolumetricLightingModel VolumetricLighting = new VolumetricLightingModel();
}
