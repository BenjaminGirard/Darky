using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem {

    private Vector3 _light;

    public LightSystem(Vector3 light)
    {
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

    public void damageLight(Vector3 dam)
    {
        _light -= dam;
    }

    public void healLight(Vector3 heal)
    {
        _light += heal;
    }
}
