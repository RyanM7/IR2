using System.Linq;
using UnityEngine;

#if !SPACE_MAIN
[AddComponentMenu("")]
#endif
public class MapRenderer : MapRendererBaseInternal
{

    public static MapRenderer Instance
    {
        get { return (MapRenderer)_mapRender; }
    }

    public void Start()
    {
        _mapRender = this;
        base.Start();
    }
}