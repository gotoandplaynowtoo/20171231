using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ULibXEventManager : MonoBehaviour {

    Dictionary<string, UnityEvent> eventDictionary = new Dictionary<string, UnityEvent>();

    static ULibXEventManager _intance;

    public static ULibXEventManager instance
    {
        get
        {
            if (_intance == null)
            {
                _intance = FindObjectOfType<ULibXEventManager>();
            }
            return _intance;
        }
    }

    public void On(string eventName, UnityAction eventHandler)
    {
        UnityEvent uEvent = null;
        if(eventDictionary.TryGetValue(eventName, out uEvent))
        {
            uEvent.AddListener(eventHandler);
        } 
        else
        {
            uEvent = new UnityEvent();
            uEvent.AddListener(eventHandler);
            eventDictionary.Add(eventName, uEvent);
        }
    }

    public void Off(string eventName, UnityAction eventHandler)
    {
        UnityEvent uEvent = null;
        if (eventDictionary.TryGetValue(eventName, out uEvent))
        {
            uEvent.RemoveListener(eventHandler);
        }
    }

    public void Emit(string eventName)
    {
        UnityEvent uEvent = null;
        if(eventDictionary.TryGetValue(eventName, out uEvent))
        {
            uEvent.Invoke();
        }
    }


}