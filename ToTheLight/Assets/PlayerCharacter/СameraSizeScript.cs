using UnityEngine;
using System.Collections;

public class СameraSizeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Camera>().orthographicSize = Screen.height / (2 * 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
