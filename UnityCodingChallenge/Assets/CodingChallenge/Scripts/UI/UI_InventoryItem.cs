using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryItem : MonoBehaviour
{
    public Image itemIcon;
    public Text itemNameLabel;
    // Start is called before the first frame update
    public void UpdateItem(Item item)
    {
        if(item == null)
        {
            Debug.LogError("UI INVENTORY ITEM: Item is null");
            return;
        }
        if (itemIcon == null)
        {
            Debug.LogError("UI INVENTORY ITEM: Item Icon not set");
        }
        else
        {
            itemIcon.sprite = ResourceManager.Instance.GetItemIcon(item.type);
        }
        if (itemNameLabel == null)
        {
            Debug.LogError("UI INVENTORY ITEM: Item name not set");
        }
        else
        {
            itemNameLabel.text = string.Format("{0} (x{1})", item.type, item.amount.ToString());
        }
    }
}
