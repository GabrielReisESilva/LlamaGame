using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move gameobject up and down in a wave (cos) trajectory
public class Bounce : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float speed = 1f;
    [Range(0.1f, 5.0f)]
    public float bounciness = 1f;
    private Vector3 startPosition;
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = startPosition + Vector3.up * Mathf.Cos(Time.time * speed) * bounciness;
        transform.localPosition = currentPosition;
    }
}
