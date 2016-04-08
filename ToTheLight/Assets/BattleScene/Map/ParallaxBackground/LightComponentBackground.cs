using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LightComponentBackground : MonoBehaviour
{

    float transparence = 1;
    public SpriteRenderer dark;
    private Color darkColor;
    private Color newColor;
    public Color cl;


    public void SetLight(float value)
    {
        darkColor = new Color(darkColor.r, darkColor.g, darkColor.b, value);
    }

    // Use this for initialization
    void Start()
    {
        darkColor = dark.color;
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
