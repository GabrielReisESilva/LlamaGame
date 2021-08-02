using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LlamaInfo : MonoBehaviour
{
    public Text llamaName;
    public Text llamaAge;
    public Text llamaHealth;
    public Image dietTypeImage;
    public GameObject starvingIcon;
    public Button feedButton;
    // Start is called before the first frame update
    public void UpdateLlamaInfo(Llama llama, Player player)
    {
        if (llama == null)
        {
            Debug.LogError("UI LLAMA INFO: Llama not set");
            return;
        }
        if (llamaName == null)
        {
            Debug.LogError("UI LLAMA INFO: Name label not set");
        }
        else
        {
            llamaName.text = llama.ID;
        }
        if (llamaAge == null)
        {
            Debug.LogError("UI LLAMA INFO: Age label not set");
        }
        else
        {
            llamaAge.text = string.Format("Age: {0}", llama.Age);
        }
        if (dietTypeImage == null)
        {
            Debug.LogError("UI LLAMA INFO: Diet image not set");
        }
        else
        {
            dietTypeImage.sprite = ResourceManager.Instance.GetItemIcon(llama.Diet);
        }
        if (feedButton == null)
        {
            Debug.LogError("UI LLAMA INFO: Feed button not set");
        }
        else
        {
            if (player != null)
            {
                feedButton.onClick.AddListener(() => { player.TryToFeedLlama(llama); });
            }
        }

        UpdateHealth(llama);
        llama.OnChangeHealth.AddListener(UpdateHealth);

    }

    private void UpdateHealth(Llama llama)
    {
        string color = llama.IsStarving ? "red" : "black";
        if (llamaHealth == null)
        {
            Debug.LogError("UI LLAMA INFO: Health label not set");
        }
        else
        {
            llamaHealth.text = string.Format("<color={0}>Health: {1}/{2}</color>", color, llama.Health, llama.MaxHealth);
        }
        starvingIcon.SetActive(llama.IsStarving);
    }
}
