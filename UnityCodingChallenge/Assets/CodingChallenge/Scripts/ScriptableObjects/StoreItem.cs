using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StoreItem", menuName = "StoreItem", order = 55)]
public class StoreItem : ScriptableObject
{
    public Sprite icon;
    public string nameInStore;
    public Item item;
    public int price;
}
