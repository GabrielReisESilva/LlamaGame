using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Store", menuName = "Store", order = 54)]
public class StoreData : ScriptableObject
{
    public string storeName;
    public StoreItem[] storeItems;
}
