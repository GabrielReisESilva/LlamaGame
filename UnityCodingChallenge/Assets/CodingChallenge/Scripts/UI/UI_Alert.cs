using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Alert : MonoBehaviour
{
    public Sprite deadIcon;
    public Sprite starvingIcon;
    public Text messageText;
    public Image statusIcon;
    // Start is called before the first frame update
    public void ShowStarvingMessage(string llamaName)
    {
        ShowMessage(string.Format("{0} is starving!", llamaName), starvingIcon);
    }
    public void ShowDeathMessage(string llamaName)
    {
        ShowMessage(string.Format("{0} is dead! :(", llamaName), deadIcon);
    }

    private void ShowMessage(string message, Sprite icon)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
        if (statusIcon != null)
        {
            statusIcon.sprite = icon;
        }

        gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(DissapearAfterTime(5));
    }

    private IEnumerator DissapearAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}