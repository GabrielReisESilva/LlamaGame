using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableIfEventSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem eventSystem = GetComponent<EventSystem>();
        if(eventSystem != null)
        {
            if(EventSystem.current != eventSystem)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
