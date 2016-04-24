using UnityEngine;
using System.Collections;

public class PlayerLayerScript : MonoBehaviour {

    private bool layer;
    public SpriteRenderer playerRender;
    public GameObject coverObject;
    private float timer;
    private bool layerTrigger;
	// Use this for initialization
	void Start () {
        layer = false;
        timer = Time.time;
	}

    void OnTriggerStay2D(Collider2D other)
    {      
        if (layer)
        {
            other.GetComponent<Opacity>().SetTransparence(true);
        }
        else
        {
            other.GetComponent<Opacity>().SetTransparence(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Opacity>().SetTransparence(false);
        // Debug.Log("Exit");
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftShift) && (timer + 0.3 <= Time.time) && coverObject.GetComponent<ActiveTrigger>().GetBlock())
        {
            layer = !layer;
            timer = Time.time;
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.01f));
            if (layer)
            {
                playerRender.sortingLayerName = "Triple";
                this.gameObject.transform.parent.gameObject.GetComponent<CharacterControl>().SetBackLayer(true);
            }
            else
            {
                playerRender.sortingLayerName = "First";
                this.gameObject.transform.parent.gameObject.GetComponent<CharacterControl>().SetBackLayer(false);
            }
        }
        coverObject.GetComponent<ActiveTrigger>().SetLayer(layer);
    }
}
