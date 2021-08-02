using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Store : MonoBehaviour
{
    public UI_StoreItem storeItemPrefab;
    public RectTransform storeLayout;
    public Text storeName;
    public Text coinsLabel;

    public StoreData store;

    private Player player;
    private int coins;
    // Start is called before the first frame update
    void Start()
    {
        if (store == null)
        {
            Debug.LogError("UI_STORE: Store Data not set");
            return;
        }
        if(storeName == null)
        {
            Debug.LogError("UI_STORE: Store Name label not set");
            return;
        }
        storeName.text = store.storeName;

        if (storeItemPrefab == null)
        {
            Debug.LogError("UI_STORE: Store Item prefab not set");
            return;
        }
        if (storeLayout == null)
        {
            Debug.LogError("UI_STORE: Store Layout not set");
            return;
        }
        for (int i = 0; i < store.storeItems.Length; i++)
        {
            UI_StoreItem storeItem = Instantiate(storeItemPrefab, storeLayout);
            storeItem.UpdateStoreItem(store.storeItems[i]);
            int index = i;
            storeItem.AddButtonListener(() => { TryPurchaseItem(store.storeItems[index]); });
        }

        coins = LlamaSceneManager.LoadCoins();
        if (coinsLabel == null)
        {
            Debug.LogError("UI_STORE: Store Layout not set");
        }

        UpdateCoins();
    }

    private void TryPurchaseItem(StoreItem item)
    {
        if(item.price > coins)
        {
            Debug.Log("UI_STORE: Item too expensive");
            return;
        }
        coins -= item.price;
        LlamaSceneManager.SaveCoins(coins);
        int itemAmount = LlamaSceneManager.LoadItem(item.item.type);
        itemAmount += item.item.amount;
        LlamaSceneManager.SaveItem(item.item.type, itemAmount);

        UpdateCoins();
    }

    public void ReturnToFarmScene()
    {
        LlamaSceneManager sceneManager = FindObjectOfType<LlamaSceneManager>();
        if(sceneManager == null)
        {
            Debug.LogError("UI_STORE: Scene Manager not found");
            return;
        }
        sceneManager.ReturnToFarmScene();
    }

    private void UpdateCoins()
    {
        coinsLabel.text = string.Format("${0}", coins);
    }
}
