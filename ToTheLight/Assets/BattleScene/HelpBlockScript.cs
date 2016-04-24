using UnityEngine;
using System.Collections;

public class HelpBlockScript : MonoBehaviour {

    public GameObject backGround;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 21)
        {
            backGround.active = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        backGround.active = true;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
