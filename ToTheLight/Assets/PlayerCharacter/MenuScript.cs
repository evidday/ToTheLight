using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 20)
        {
            other.gameObject.GetComponent<EndLocationScript>().SetActiveMenu(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 20)
        {
            other.gameObject.GetComponent<EndLocationScript>().SetActiveMenu(false);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
