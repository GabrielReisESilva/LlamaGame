using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnObjectClicked : MonoBehaviour
{
    public UnityEvent onClicked;
    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            onClicked?.Invoke();
        }
    }
}
