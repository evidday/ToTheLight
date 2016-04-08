using UnityEngine;
using System.Collections;

public class MidBlockFlip : MonoBehaviour {

    public SpriteRenderer collored;
    public SpriteRenderer dark;

	// Use this for initialization
	void Start () {
	
	}

    public void SetFlip() {
        collored.flipX = true;
        dark.flipX = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
