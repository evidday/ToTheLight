﻿using UnityEngine;
using System.Collections;

public class ItemInventory : MonoBehaviour {

    private Item[,] inv;
    public int n;
    public int m;
    private GameObject go;

    private bool showInventory = false;
    private int pixSize = 28;

    public void SetActive(bool act)
    {
        showInventory = act;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((other.gameObject.transform.parent.gameObject.layer == 9) && (this.gameObject.transform.parent.gameObject.layer == 11)) ||
                (other.gameObject.transform.parent.gameObject.layer == 21) && (this.gameObject.transform.parent.gameObject.layer == 15))
        {
            other.GetComponent<ShowChestsSystem>().NewChest(this.gameObject);
            go = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (((other.gameObject.transform.parent.gameObject.layer == 21) && (this.gameObject.transform.parent.gameObject.layer == 11)) ||
                (other.gameObject.transform.parent.gameObject.layer == 9) && (this.gameObject.transform.parent.gameObject.layer == 15))
        {
            other.GetComponent<ShowChestsSystem>().DeleteChest(this.gameObject);
            showInventory = false;
        }
        else
        {
            other.GetComponent<ShowChestsSystem>().TryNewChest(this.gameObject);
            go = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (((other.gameObject.transform.parent.gameObject.layer == 9) && (this.gameObject.transform.parent.gameObject.layer == 11)) ||
                (other.gameObject.transform.parent.gameObject.layer == 21) && (this.gameObject.transform.parent.gameObject.layer == 15))
        {
            other.GetComponent<ShowChestsSystem>().DeleteChest(this.gameObject); 
            showInventory = false;
        }
    }

    // Use this for initialization
    void Start () {
        n = 2;
        m = 4;
        inv = new Item[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                inv[i, j] = new Item();
                inv[i, j].Generate();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
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
                    go.GetComponent<PlayerInventory>().ClearItem(x, y);
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

    public void ClearItem(int i, int j)
    {
        inv[i, j].Clear();
    }

    void OnGUI()
    {
        if (showInventory)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (GUI.Button(new Rect(Screen.width / 4 * 3 - pixSize * (2 - i), Screen.height / 2 - pixSize * (3 - j), pixSize, pixSize), "" + inv[i, j].id))
                    {
                        go.GetComponent<PlayerInventory>().SetItem(inv[i, j], i, j);
                    }
                }
            }
        }
    }
}