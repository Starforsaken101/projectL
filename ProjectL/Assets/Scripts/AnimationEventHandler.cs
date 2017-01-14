using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimationEventHandler : MonoBehaviour
{
    public UnityEvent OnAnimationEvent = new UnityEvent();

    public void InvokeAnimationEvent()
    {
        OnAnimationEvent.Invoke();
    }
}
