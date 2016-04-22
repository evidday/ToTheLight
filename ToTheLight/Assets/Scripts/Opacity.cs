using UnityEngine;
using System.Collections;

public class Opacity : MonoBehaviour {

    public SpriteRenderer dark;
    public SpriteRenderer colored;
    private float lightTransparence;
    private bool transparence;
    private float opacity;
    private float backModifier;
    private float backPlus;
    private float backLightModifier;
    public Light lightSourceColored = null;
    public Light lightSourceDark = null;

    public void SetLightTransparence(float tr)
    {
        lightTransparence = tr;
    }

    public void SetTransparence(bool tr)
    {
        transparence = tr;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        backModifier = 1;
        backPlus = 0f;
        backLightModifier = 1;
        if (this.gameObject.layer == 15) // BackLayer
        {
            backModifier = 2.2f;
            backPlus = 0.35f;
            if (transparence)
            {
                backLightModifier = 5f;
            }
        }
        if (transparence)
        {
            opacity = 0.4f;
        }
        else
        {
            opacity = 1f;
        }
        float help = 1;
        if (lightTransparence == 1)
        {
            help = 0;
        }
       // Debug.Log(help * (float)opacity * (1 - Mathf.Max(Mathf.Min(lightTransparence * backModifier * Mathf.Abs(Mathf.Atan(lightTransparence) / 2), 1), 0)));
        dark.color = new Color(dark.color.r, dark.color.g, dark.color.b, (float)opacity * Mathf.Max(0, Mathf.Min(1, lightTransparence  * backModifier * backLightModifier * Mathf.Abs(Mathf.Atan(lightTransparence + Mathf.PI / 2)))) + backPlus);
        colored.color = new Color(colored.color.r, colored.color.g, colored.color.b, help * (float)opacity * (1 - Mathf.Max(Mathf.Min(lightTransparence*backModifier*Mathf.Abs(Mathf.Atan(lightTransparence) / 2), 1), 0)));
        if (lightSourceColored != null)
        {
            lightSourceColored.intensity = 4 * (opacity - (opacity) * (lightTransparence) * backModifier);
            lightSourceDark.intensity = 2 * (lightTransparence * opacity * backModifier * backLightModifier + backPlus);
        }
    }
}
