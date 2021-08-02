using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FarmHouse : MonoBehaviour
{
    public Player player;
    public Pen pen;
    public UI_LlamaInfo uiLlamaInfoPrefab;
    public RectTransform gridLayout;
    public Text llamaCountLabel;
    // Start is called before the first frame update
    public void ShowLlamaInfo()
    {
        if (player == null)
        {
            Debug.LogError("UI FARM HOUSE: Player not set");
            return;
        }
        if (pen == null)
        {
            Debug.LogError("UI FARM HOUSE: Pen not set");
            return;
        }

        if (gridLayout == null)
        {
            Debug.LogError("UI FARM HOUSE: Layout not set");
            return;
        }

        for (int i = 0; i < gridLayout.childCount; i++)
        {
            Destroy(gridLayout.GetChild(i).gameObject);
        }

        if (uiLlamaInfoPrefab == null)
        {
            Debug.LogError("UI FARM HOUSE: Prefab not set");
            return;
        }

        if (pen.CapturedLlamas!= null)
        {
            for (int i = 0; i < pen.CapturedLlamas.Count; i++)
            {
                UI_LlamaInfo item = Instantiate(uiLlamaInfoPrefab, gridLayout);
                item.UpdateLlamaInfo(pen.CapturedLlamas[i], player);
            }
        }
        if(llamaCountLabel != null)
        {
            llamaCountLabel.text = string.Format("{0}/{1}", pen.CapturedLlamas.Count, Pen.MAX_CAPTURED_LLAMAS);
        }

        gameObject.SetActive(true);
    }
}
