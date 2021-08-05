using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Highlight objects when mouse in hovers over it
public class HighlightOnMouseOver : MonoBehaviour
{
    public Color highlightColor;
    private Color originalColor;
    private Material material;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        material = new Material(rend.material);
        rend.material = material;
        originalColor = material.GetColor("_BaseColor");
    }

    void OnMouseEnter()
    {
        material.SetColor("_BaseColor", highlightColor);
    }

    void OnMouseExit()
    {
        material.SetColor("_BaseColor", originalColor);
    }
}