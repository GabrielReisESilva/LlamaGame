using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ItemType
    {
        GRASS,
        FLOWER,
        SHRUB
    }

    public ItemType type;
    public int amount;

    public Item(ItemType type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }
}
