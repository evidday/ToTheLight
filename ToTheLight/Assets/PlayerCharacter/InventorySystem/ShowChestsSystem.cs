using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowChestsSystem : MonoBehaviour {

    private HashSet<GameObject> chestList = new HashSet<GameObject>();
    private GameObject chosen = null;
    private float timer;
    private bool grab = false;

    public void NewChest(GameObject go)
    {
        chestList.Add(go);
        if (chestList.Count == 1)
        {
            chosen = go;
            this.gameObject.GetComponent<PlayerInventory>().SetChosen(chosen);
        }

    }

    public void DeleteChest(GameObject go)
    {
        if (chosen == go)
        {
            NextChest();
        }
        chestList.Remove(go);
        if (chestList.Count == 0)
        {
            chosen = null;
            this.gameObject.GetComponent<PlayerInventory>().SetChosen(chosen);
            grab = false;
        }
    }

    public void TryNewChest(GameObject go)
    {
        if (!chestList.Contains(go))
        {
            chestList.Add(go);
            if (chestList.Count == 1)
            {
                chosen = go;
                this.gameObject.GetComponent<PlayerInventory>().SetChosen(chosen);
            }
        }
    }

    public void TryDeleteChest(GameObject go)
    {
        if (chestList.Contains(go))
        {
            chestList.Remove(go);
            if (chestList.Count == 0)
            {
                chosen = null;
                this.gameObject.GetComponent<PlayerInventory>().SetChosen(chosen);
                grab = false;
            }
        }
    }

    // Use this for initialization
    void Start () {
        timer = Time.time;
	}

    private void Active(GameObject go, bool act)
    {
        go.GetComponent<ItemInventory>().SetActive(act);
    }

    private void PreviousChest()
    {
        int i = 0;
        foreach (var item in chestList)
        {
            if (item == chosen)
            {
                Active(chosen, false);
                break;
            }
            i++;
        }
        if (i == 0)
        {
            i = chestList.Count - 1;
        }
        else
        {
            i--;
        }
        int j = 0;
        foreach (var item in chestList)
        {
            if (j == i)
            {
                chosen = item;
                this.gameObject.GetComponent<PlayerInventory>().SetChosen(chosen);
                Active(chosen, grab);
            }
            j++;
        }
    }

    private void NextChest()
    {
        int i = 0;
        foreach (var item in chestList)
        {
            if (item == chosen)
            {
                Active(chosen, false);
                break;
            }
            i++;
        }
        if (i == chestList.Count - 1)
        {
            i = 0;
        }
        else
        {
            i++;
        }
        int j = 0;
        foreach (var item in chestList)
        {
            if (j == i)
            {
                chosen = item;
                this.gameObject.GetComponent<PlayerInventory>().SetChosen(chosen);
                Active(chosen, grab);
            }
            j++;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (chosen == null)
        {
            this.GetComponent<PlayerInventory>().SetGrabItem(false);
        }
        else
        {
            if (Input.GetKey(KeyCode.F) && (timer + 0.3 <= Time.time))
            {
                grab = !grab;
                this.gameObject.GetComponent<PlayerInventory>().SetGrabItem(grab);
                Active(chosen, grab);
                timer = Time.time;
            }
            if (grab)
            {
                if (Input.GetKey(KeyCode.LeftArrow) && (timer + 0.3 <= Time.time))
                {
                    PreviousChest();
                    timer = Time.time;
                }
                if (Input.GetKey(KeyCode.RightArrow) && (timer + 0.3 <= Time.time))
                {
                    NextChest();
                    timer = Time.time;
                }
            }
        }
	}
}
