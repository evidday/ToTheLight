using UnityEngine;
using System.Collections;

public class MidFlip : MonoBehaviour {

    public GameObject background;

	// Use this for initialization
	void Start () {
	
	}

    public void Flip()
    {
        background.GetComponent<MidBlockFlip>().SetFlip();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
