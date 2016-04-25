using UnityEngine;
using System.Collections;

public class Item
{
    public int id = 0;
    
    public void Generate()
    {
        this.id = Random.Range(1, 5);
    }

    public void Clear()
    {
        this.id = 0;
    }

    public Item Copy()
    {
        Item copyItem = new Item();
        copyItem.id = this.id;
        return copyItem;
    }
}
