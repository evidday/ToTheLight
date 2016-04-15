using UnityEngine;
using System.Collections;

public class ActiveTrigger : MonoBehaviour {

    private bool activeZone;
    private bool coverZone;
    private Transform coverTransform;
    public GameObject hitObject;
    private float timer;
    private bool inCover;
    private bool layer;
    private bool leftCover;
    private int counter;

	// Use this for initialization
	void Start () {
        timer = Time.time;
        inCover = false;
        activeZone = false;
        coverZone = false;
        layer = false;
        leftCover = false;
        counter = 0;
	}

    public void SetLayer(bool la)
    {
        layer = la;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log(other.gameObject.tag);
       if (other.gameObject.tag == "Block")
       {
           counter++;
       }
        Debug.Log(other.gameObject.transform.parent.gameObject.layer);
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

    public bool GetBlock()
    {
        if (counter != 0)
        {
            return false;
        }
        return true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Block")
        {
            counter--;
        }
        coverZone = false;
        activeZone = false;
        inCover = false;
    }

    private void OutOfCover()
    {
        hitObject.transform.position = gameObject.transform.parent.gameObject.transform.position;
        inCover = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.E) && (timer + 0.3 <= Time.time) && activeZone)
        {
            if (coverZone)
            {
                if (!inCover)
                {
                    inCover = !inCover;
                    if (inCover)
                    {
                        hitObject.transform.position = new Vector3(coverTransform.position.x, this.transform.position.y, this.transform.position.z);
                    }
                }
                else
                {
                    OutOfCover();
                }
            }
            timer = Time.time;
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.01f));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            OutOfCover();
        }
    }
}
