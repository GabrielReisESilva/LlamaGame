using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlamaSceneManager : MonoBehaviour
{
    private const string coins_key = "coins";
    private const string item_key = "item_";
    // Start is called before the first frame update
    private static LlamaSceneManager llamaSceneManager;
    public Player player;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (llamaSceneManager == null)
        {
            llamaSceneManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.DeleteAll();
    }
    public void ReturnToFarmScene()
    {
        SceneManager.UnloadSceneAsync("StoreScene");
        LoadPlayerData();
        Time.timeScale = 1;
    }

    public void LoadStoreScene()
    {
        SavePlayerData();
        Time.timeScale = 0;
        SceneManager.LoadScene("StoreScene", LoadSceneMode.Additive);
    }

    public void LoadFarmScene()
    {
        SceneManager.LoadScene("CodingChallengeScene", LoadSceneMode.Single);
    }

    public void SavePlayerData()
    {
        if(player != null)
        {
            PlayerPrefs.SetInt(coins_key, player.Coins);
            if(player.Inventory != null)
            {
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    PlayerPrefs.SetInt("item_" + player.Inventory[i].type, player.Inventory[i].amount);
                }
            }
        }
    }
    public void LoadPlayerData()
    {
        int coins = LoadCoins();
        List<Item> inventory = new List<Item>();
        foreach (Item.ItemType item in (Item.ItemType[])System.Enum.GetValues(typeof(Item.ItemType)))
        {
            int amount = LoadItem(item);
            if(amount > 0)
            {
                inventory.Add(new Item(item, amount));
            }
        }
        if(player != null)
        {
            player.SetData(coins, inventory);
        }
    }

    public static void ChangeScene(string sceneName, bool isAdditive)
    {
        SceneManager.LoadScene(sceneName, isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }

    public static int LoadCoins()
    {
        return PlayerPrefs.GetInt(coins_key, 0);
    }
    public static void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt(coins_key, coins);
    }
    public static int LoadItem(Item.ItemType type)
    {
        return PlayerPrefs.GetInt(item_key + type, 0);
    }
    public static void SaveItem(Item.ItemType type, int amount)
    {
        PlayerPrefs.SetInt(item_key + type, amount);
    }
}
