using UnityEngine;
using System.Collections;

public class Opacity : MonoBehaviour {

    public SpriteRenderer dark;
    public SpriteRenderer colored;
    private float lightTransparence;
    private bool transparence;
    private float opacity;

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
        if (transparence)
        {
            opacity = 0.2f;
        }
        else
        {
            opacity = 1f;
        }
        dark.color = new Color(dark.color.r, dark.color.g, dark.color.b, (float)(lightTransparence * opacity));
        colored.color = new Color(colored.color.r, colored.color.g, colored.color.b, opacity);
    }
}
