using UnityEngine;
using System.Collections;

public class ActiveTrigger : MonoBehaviour {

    private bool activeZone;
    private bool coverZone;
    private Transform coverTransform;
    private float timer;
    private bool inCover;
    private bool layer;
    private bool leftCover;

	// Use this for initialization
	void Start () {
        timer = Time.time;
        inCover = false;
        activeZone = false;
        coverZone = false;
        layer = false;
        leftCover = false;
	}

    public void SetLayer(bool la)
    {
        layer = la;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(layer);
        if ((layer && (other.gameObject.transform.parent.gameObject.layer == 15)) || (!layer && (other.gameObject.transform.parent.gameObject.layer != 15))) //BackLayer
        {
            activeZone = true;
            coverTransform = other.transform;
            if ((other.gameObject.layer == 16) && (other.gameObject.GetComponent<Cover>().coverState != 0))//Active Object
            {
                if(other.gameObject.GetComponent<Cover>().coverState == 1)
                {
                    leftCover = false;
                }
                else
                {
                    leftCover = true;
                }
                coverZone = true;
            }
            else
            {
                coverZone = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        coverZone = false;
        activeZone = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.E) && (timer + 0.3 <= Time.time) && activeZone)
        {
            if (coverZone)
            {
                inCover = !inCover;
                if (inCover)
                {
                    this.gameObject.transform.root.gameObject.transform.position = new Vector3(coverTransform.position.x, this.transform.position.y, this.transform.position.z);
                }
            }
            timer = Time.time;
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.01f));
        }
    }
}
