using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//Invokes "onClicked" method(s) when object is clicked
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
