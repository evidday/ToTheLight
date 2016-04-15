using UnityEngine;
using System.Collections;

public class MidBlockFlip : MonoBehaviour {

    public SpriteRenderer colored;
    public SpriteRenderer dark;

	// Use this for initialization
	void Start () {
	
	}

    public void SetOpacity(float tr)
    {
        dark.color = new Color(dark.color.r, dark.color.g, dark.color.b, (float)(tr));
        //colored.color = new Color(colored.color.r, colored.color.g, colored.color.b, opacity - (opacity) * (lightTransparence) * backModifier);
    }

    public void SetFlip() {
        colored.flipX = true;
        dark.flipX = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
