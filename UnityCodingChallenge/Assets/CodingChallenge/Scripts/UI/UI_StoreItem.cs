using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_StoreItem : MonoBehaviour
{
    public Image itemIcon;
    public Text itemName;
    public Text priceLabel;
    public Button button;

    public void UpdateStoreItem(StoreItem item)
    {
        if(itemIcon == null)
        {
            Debug.LogError("UI STORE ITEM: icon not found");
        }
        else
        {
            itemIcon.sprite = item.icon;
        }

        if (itemName == null)
        {
            Debug.LogError("UI STORE ITEM: name label not found");
        }
        else
        {
            itemName.text = item.nameInStore;
        }

        if (priceLabel == null)
        {
            Debug.LogError("UI STORE ITEM: price label not found");
        }
        else
        {
            priceLabel.text = string.Format("PURCHASE (${0})", item.price);
        }
    }

    public void AddButtonListener(UnityAction onClick)
    {
        if(button != null)
        {
            button.onClick.AddListener(onClick);
        }
        else
        {
            Debug.LogError("UI STORE ITEM: Button not set");
        }
    }
}
