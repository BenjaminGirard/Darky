using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem {

    private Vector3 _light;
    private float MaxLightScale;
    private float MinLightScale;

    public float getMinLightScale() {
        return MinLightScale;
    }
    public LightSystem(Vector3 light)
    {
        MaxLightScale = light.x;
        MinLightScale = 0.3f;
        _light = light;
    }

    public Vector3 getLight()
    {
        return _light;
    }

    public void setLight(Vector3 l)
    {
        _light = l;
    }

    public Vector3 damageLight(Vector3 dam)
    {
        if (_light.x - dam.x < MinLightScale)
            _light = new Vector3(MinLightScale, MinLightScale, MinLightScale);
        else
            _light -= dam;
        return _light;
    }

    public Vector3 healLight(Vector3 heal)
    {
        if (_light.x + heal.x > MaxLightScale)
            _light = new Vector3(MaxLightScale, MaxLightScale, MaxLightScale);
        else
            _light += heal;
        return _light;
    }
}
