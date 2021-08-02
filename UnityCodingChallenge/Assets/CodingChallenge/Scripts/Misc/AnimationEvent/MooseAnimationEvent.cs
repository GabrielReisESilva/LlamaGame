using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MooseAnimationEvent : MonoBehaviour
{
    public UnityEvent footstepEvent;
    public void FootstepEvent()
    {
        footstepEvent?.Invoke();
    }
}
