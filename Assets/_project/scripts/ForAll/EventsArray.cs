using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _events;
    void StartEvent(int eventIndex)
    {
        _events[eventIndex].Invoke();
    }
}
