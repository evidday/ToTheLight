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
            backPlus = 0.5f;
            if (transparence)
            {
                backLightModifier = 5f;
            }
        }
        if (transparence)
        {
            opacity = 0.5f;
        }
        else
        {
            opacity = 1f;
        }
        dark.color = new Color(dark.color.r, dark.color.g, dark.color.b, (float)(lightTransparence * opacity * backModifier * backLightModifier) + backPlus);
        colored.color = new Color(colored.color.r, colored.color.g, colored.color.b, opacity - (opacity)*(lightTransparence)*backModifier);
    }
}
