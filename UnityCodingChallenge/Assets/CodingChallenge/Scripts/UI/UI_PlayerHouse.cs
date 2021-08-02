using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerHouse : MonoBehaviour
{
    public Player player;
    public UI_InventoryItem uiInventoryItemPrefab;
    public RectTransform gridLayout;
    // Start is called before the first frame update
    public void ShowInventory()
    {
        if(player == null)
        {
            Debug.LogError("UI PLAYER HOUSE: Player not set");
            return;
        }

        if(gridLayout == null)
        {
            Debug.LogError("UI PLAYER HOUSE: Layout not set");
            return;
        }

        for (int i = 0; i < gridLayout.childCount; i++)
        {
            Destroy(gridLayout.GetChild(i).gameObject);
        }

        if (uiInventoryItemPrefab == null)
        {
            Debug.LogError("UI PLAYER HOUSE: Prefab not set");
            return;
        }

        if(player.Inventory != null)
        {
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                UI_InventoryItem item = Instantiate(uiInventoryItemPrefab, gridLayout);
                item.UpdateItem(player.Inventory[i]);
            }
        }

        gameObject.SetActive(true);
    }
}
