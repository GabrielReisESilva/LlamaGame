using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [Range(0.01f, 1.0f)]
    public float smooth = 0.9f;


    private Vector3 offset;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            offset = transform.position - player.position;
        }
        else
        {
            Debug.LogError("FOLLOW PLAYER: Player transform not set!");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            pos = player.position + offset;

            transform.position = Vector3.Slerp(transform.position, pos, smooth);
        }
    }
}
