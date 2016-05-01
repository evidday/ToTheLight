using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightCounter : MonoBehaviour {

	// Use this for initialization
    private int lightCounter;
    private int showLight;
    private bool showLightFlag = false;
    private float maxLength = (float)20;
    private int maxLight = 1000;
    private GameObject sceneStarter;
    private float timer = Time.time;;

    public void PlusLight(int light)
    {
        lightCounter += light;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<LightComponent>().NewLight(this.name, 0);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        float dist = Vector2.Distance(this.transform.position, other.transform.position);
       // Debug.Log(lightCounter / maxLight * (maxLength - dist) / maxLength);
        other.GetComponent<LightComponent>().AddLight(this.name, (float)lightCounter / maxLight * (maxLength - dist) / maxLength);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<LightComponent>().DeleteLight(this.name);
       // Debug.Log("Exit");
    }

    void Start () {
        lightCounter = 1000;
        foreach (GameObject start in GameObject.FindGameObjectsWithTag("SceneStarter"))
        {
            sceneStarter = start;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q) && (timer + 0.3 <= Time.time))
        {
            showLightFlag = !showLightFlag;
            timer = Time.time;
        }
        if (showLightFlag)
        {
            showLight = lightCounter;
        }
        else
        {
            showLight = 0;
        }
        sceneStarter.GetComponent<SceneGenerator>().SetLight(1 - (float)showLight/ (float)maxLight);
        this.GetComponent<CircleCollider2D>().radius = 17.3f * showLight / maxLight;// new Vector3(lightCounter / maxLight, lightCounter / maxLight, lightCounter / maxLight);
	}
}
