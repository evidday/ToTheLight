using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LightComponent : MonoBehaviour {

    private Dictionary<string, float> lightList = new Dictionary<string, float>();
    float transparence = 0;
    public GameObject darkLayer;
    public SpriteRenderer dark;
    private Color darkColor;
    private Color newColor;
    public Color cl;


    public void NewLight(string name, float value)
    {
        lightList.Add(name, value);
    }

    public void AddLight(string name, float value)
    {
        lightList.Remove(name);
        lightList.Add(name, value);
    }

    public void DeleteLight(string name)
    {
        lightList.Remove(name);
    }

	// Use this for initialization
	void Start () {
        darkColor = darkLayer.GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame

    void Update () {
       // Debug.Log(dark.color.a);
        transparence = 0;
        foreach (var item in lightList)
        {
            transparence += item.Value;
        }
        newColor.a = 0f;// transparence / 100;
        transparence = 1 - Math.Min(transparence, 100);
        // Debug.Log(transparence);
        this.GetComponent<Opacity>().SetLightTransparence(transparence); //dark.color = new Color(darkColor.r, darkColor.g, darkColor.b, transparence);
        //  darkColor = newColor;
    }
}
