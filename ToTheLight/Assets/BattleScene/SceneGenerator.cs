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

    private void MapCreator(GameObject[] begin, GameObject[] mid, GameObject[] end)
    {
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
