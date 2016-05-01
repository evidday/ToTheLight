using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    private Item[] quickMenu;
    private Item[,] inv;
    private GameObject chosen;
    public int n;
    public int m;
    private int pixSize = 28;
    private bool showInventory = false;
    private bool grabItem = false;
    private float timer;

    public GameObject throwItemBack;
    public GameObject throwItemMid;
    public GameObject lightObject;

    public GameObject throwPos;

    public void PlusLight(int light)
    {
        lightObject.GetComponent<LightCounter>().PlusLight(light);
    }

    public void SetItem(Item it, int x, int y)
    {
        bool f = false;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (inv[i, j].id == 0)
                {
                    inv[i, j] = it.Copy();
                    chosen.GetComponent<ItemInventory>().ClearItem(x, y);
                    f = true;
                    break;
                }
            }
            if (f)
            {
                break;
            }
        }
    }

    public void ThrowItem(Item it, int x, int y)
    {
        GameObject go;
        if (gameObject.transform.parent.gameObject.layer == 9)
        {
            go = (GameObject)GameObject.Instantiate(throwItemMid, throwPos.gameObject.transform.position, throwPos.gameObject.transform.rotation);
            go.GetComponentInChildren<ItemInventory>().SetIniItem(it, x, y, this.gameObject);
        }
        else
        {
            go = (GameObject)GameObject.Instantiate(throwItemBack, throwPos.gameObject.transform.position, throwPos.gameObject.transform.rotation);
            go.GetComponentInChildren<ItemInventory>().SetIniItem(it, x, y, this.gameObject);
        }
    }

    public void SetChosen(GameObject go)
    {
        chosen = go;
    }

    public void ClearItem(int i, int j)
    {
        inv[i, j].Clear();
    }

    public void SetGrabItem(bool tf)
    {
        grabItem = tf;
    }

    private void LoadInventory()
    {
        for (int i = 0; i < 10; i++)
        {
            quickMenu[i] = new Item();
            quickMenu[i].id = 0;
        }
        inv = new Item[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                inv[i, j] = new Item();
                inv[i, j].Clear();
            }
        }
    }

	// Use this for initialization
	void Start () {
        quickMenu = new Item[10];
        timer = 0;
        LoadInventory();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.I) && (timer + 0.3 <= Time.time) && (!grabItem))
        {
            showInventory = !showInventory;
            timer = Time.time;
        }
    }

    void OnGUI()
    {
        for(int i = 0; i < 10; i++)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - pixSize * (5 - i), Screen.height - 3 * pixSize, pixSize, pixSize), ""))
            {
                
            }
        }
        if (showInventory || grabItem)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (GUI.Button(new Rect(Screen.width / 4 - pixSize * (2 - i), Screen.height / 4 + pixSize * (3 - j), pixSize, pixSize), "" + inv[i, j].id))
                    {
                        if ((Event.current.button == 0))
                        {
                            if (chosen != null)
                            {
                                chosen.GetComponent<ItemInventory>().SetItem(inv[i, j], i, j);
                            }
                        }
                        else
                        {
                            ThrowItem(inv[i, j], i, j);
                        }
                    }
                }
            }
        }
    }
}
