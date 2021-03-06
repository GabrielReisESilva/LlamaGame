using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pen : MonoBehaviour
{
    public const int MAX_CAPTURED_LLAMAS = 15;

    private List<Llama> capturedLlamas;
    public UI_Alert alert;
    public Transform penCenter;
    public UnityEvent<Vector3> onLlamaCaptured;

    public List<Llama> CapturedLlamas { get => capturedLlamas; }

    void Start()
    {
        capturedLlamas = new List<Llama>();
    }
    public bool TryCaptureLlama(Llama llama)
    {
        if(llama == null)
        {
            Debug.LogError("PEN: Can't capture unexisting llama");
            return false;
        }
        //Tries to capture a llama if has enough room in the pen. Sets listeners to the captured llama
        if (capturedLlamas.Count < MAX_CAPTURED_LLAMAS)
        {
            onLlamaCaptured?.Invoke(llama.transform.position);
            llama.GetCaptured(penCenter.position);
            llama.OnStarving?.AddListener(OnLlamaStarving);
            llama.OnDeath?.AddListener(OnLlamaDead);
            capturedLlamas.Add(llama);
            return true;
        }
        else
        {
            return false;
        }
    }
    //Show modal message when llama is starving
    private void OnLlamaStarving(Llama llama)
    {
        if(alert != null)
        {
            alert.ShowStarvingMessage(llama.ID);
        }
    }

    //Show modal message when llama is dead. Open a spot in the pen for a new llama
    private void OnLlamaDead(Llama llama)
    {
        if(capturedLlamas != null && llama != null)
        {
            capturedLlamas.Remove(llama);
        }
        if (alert != null)
        {
            alert.ShowDeathMessage(llama.ID);
        }
    }
}
