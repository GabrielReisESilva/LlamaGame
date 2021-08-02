using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> inventory;
    // Start is called before the first frame update
    public List<Item> List { get => inventory; }
    void Start()
    {
        inventory = new List<Item>();
    }

    public void AddItem(Item item, int amount)
    {
        if(inventory != null)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].type == item.type)
                {
                    inventory[i].amount += amount;
                }
            }
        }
    }
    public Item GetItem(Item.ItemType item)
    {
        if (inventory != null)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].type == item)
                {
                    return inventory[i];
                }
            }
        }
        return null;
    }

    public void SetList(List<Item> items)
    {
        inventory = items;
    }
}
