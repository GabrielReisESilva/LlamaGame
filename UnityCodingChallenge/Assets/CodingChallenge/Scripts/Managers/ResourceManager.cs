using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;

    public static ResourceManager Instance { get { return _instance; } }

    public Sprite grassIcon;
    public Sprite flowerIcon;
    public Sprite shrubIcon;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Sprite GetItemIcon(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.GRASS:
                return grassIcon;
            case Item.ItemType.FLOWER:
                return flowerIcon;
            case Item.ItemType.SHRUB:
                return shrubIcon;
            default:
                return grassIcon;
        }
    }
}