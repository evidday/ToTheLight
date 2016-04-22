using UnityEngine;
using System.Collections;

public class LightCounter : MonoBehaviour {

	// Use this for initialization
    private int lightCounter;
    private float maxLength = (float)20;
    private int maxLight = 1000;
    private GameObject sceneStarter;

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
        sceneStarter.GetComponent<SceneGenerator>().SetLight(1 - (float)lightCounter / (float)maxLight);
        this.GetComponent<CircleCollider2D>().radius = 17.3f * lightCounter / maxLight;// new Vector3(lightCounter / maxLight, lightCounter / maxLight, lightCounter / maxLight);
	}
}
