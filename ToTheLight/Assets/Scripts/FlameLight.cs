using UnityEngine;
using System.Collections;

public class FlameLight : MonoBehaviour {

    Light lightComponent;
    int randSyst;
    int speed;

	// Use this for initialization
	void Start () {
        lightComponent = this.gameObject.GetComponent<Light>();
        randSyst = Random.RandomRange(0, 3);
        speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
	    if (randSyst == 0)
        {
           // lightComponent.intensity += Mathf.Sin(speed * Time.time) / 3 + Mathf.Cos(speed * Time.time) / 3 + Mathf.Sin(speed * Time.time)*Mathf.Sin(speed * Time.time*3) / 3;
            lightComponent.range = 30 + 20 *(Mathf.Sin(speed * Time.time) / 3 + Mathf.Cos(speed * Time.time) / 3 + Mathf.Sin(speed * Time.time) * Mathf.Sin(speed * Time.time * 3) / 3);
        }
        if (randSyst == 1)
        {
          ///  lightComponent.intensity += Mathf.Sin(speed * Time.time) / 3 + Mathf.Sin(speed * Time.time * 2) / 3 + Mathf.Cos(speed * Time.time) * Mathf.Sin(speed * Time.time * 3) / 3;
            lightComponent.range = 30 + 20 *(Mathf.Sin(speed * Time.time) / 3 + Mathf.Sin(speed * Time.time * 2) / 3 + Mathf.Cos(speed * Time.time) * Mathf.Sin(speed * Time.time * 3) / 3);
        }
        if (randSyst == 2)
        {
           // lightComponent.intensity += Mathf.Cos(speed * Time.time) / 3 + Mathf.Cos(speed * Time.time * 2) / 3 + Mathf.Cos(speed * Time.time) * Mathf.Cos(speed * Time.time * 3) / 3;
            lightComponent.range = 30 + 20*(Mathf.Cos(speed * Time.time) / 3 + Mathf.Cos(speed * Time.time * 2) / 3 + Mathf.Cos(speed * Time.time) * Mathf.Cos(speed * Time.time * 3) / 3);
        }
    }
}
