using UnityEngine;
using System.Collections;

public class SceneGenerator : MonoBehaviour {

    public GameObject startPoint;
    public GameObject midPoint1;
    public GameObject midPoint2;
    public GameObject midPoint3;
    public GameObject endPoint;

    public GameObject[] forestStartBlocks;
    public GameObject[] forestMidBlocks;
    public GameObject[] forestEndBlocks;

    public GameObject[] forestNightBackground;

    private GameObject b0;
    private GameObject b1;
    private GameObject b2;
    private GameObject b3;
    private GameObject b4;
    private GameObject b5;
    private GameObject b6;


    private void MapCreator(GameObject[] begin, GameObject[] mid, GameObject[] end)
    {
        int randomBackground = Random.Range(0, forestNightBackground.Length - 1);
        b0 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(startPoint.transform.position.x - (float)8.7 * 2.725f, startPoint.transform.position.y + (float)6.5 * 2.45f, 12), startPoint.transform.rotation);
        b1 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(startPoint.transform.position.x + (float)8.7 * 2.725f, startPoint.transform.position.y + (float)6.5 * 2.45f, 12), startPoint.transform.rotation);
        b2 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(midPoint1.transform.position.x + (float)8.7 * 2.725f, midPoint1.transform.position.y + (float)6.5 * 2.45f, 12), midPoint1.transform.rotation);
        b3 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(midPoint2.transform.position.x + (float)8.7 * 2.725f, midPoint2.transform.position.y + (float)6.5 * 2.45f, 12), midPoint2.transform.rotation);
        b4 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(midPoint3.transform.position.x + (float)8.7 * 2.725f, midPoint3.transform.position.y + (float)6.5 * 2.45f, 12), midPoint3.transform.rotation);
        b5 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(endPoint.transform.position.x + (float)8.7 * 2.725f, endPoint.transform.position.y + (float)6.5 * 2.45f, 12), endPoint.transform.rotation);
        b6 = (GameObject)GameObject.Instantiate(forestNightBackground[randomBackground], new Vector3(endPoint.transform.position.x + 47.5f + (float)8.7 * 2.725f, endPoint.transform.position.y + (float)6.5 * 2.45f, 12), endPoint.transform.rotation);
        b0.GetComponent<MidBlockFlip>().SetFlip();
        b2.GetComponent<MidBlockFlip>().SetFlip();
        b4.GetComponent<MidBlockFlip>().SetFlip();
        b6.GetComponent<MidBlockFlip>().SetFlip();
        GameObject.Instantiate(begin[Random.Range(0, begin.Length - 1)], startPoint.transform.position, startPoint.transform.rotation);
        GameObject.Instantiate(mid[Random.Range(0, mid.Length - 1)], midPoint1.transform.position, midPoint1.transform.rotation);
        GameObject.Instantiate(mid[Random.Range(0, mid.Length - 1)], midPoint2.transform.position, midPoint2.transform.rotation);
        GameObject.Instantiate(mid[Random.Range(0, mid.Length - 1)], midPoint3.transform.position, midPoint3.transform.rotation);
        GameObject.Instantiate(end[Random.Range(0, end.Length - 1)], endPoint.transform.position, endPoint.transform.rotation);
    }

    private void LoadLocation() {
      //  switch (PlayerPrefs.GetString("firstMapType"))
       // {
        //    case "Forest":
                MapCreator(forestStartBlocks, forestMidBlocks, forestEndBlocks);
         //       break;
       // }
    }


	// Use this for initialization
	void Start () {
        LoadLocation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
