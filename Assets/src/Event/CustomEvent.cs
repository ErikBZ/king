using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CustomEvenet", menuName = "king/CustomEvent", order = 0)]
public class CustomEvent : ScriptableObject
{
    private List<CustomEventListener> listeners = new List<CustomEventListener>();

    public void Raise()
    {
        // going through this backwards to avoid Index out of bounds when removing items
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(CustomEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(CustomEventListener listener)
    {
        listeners.Remove(listener);
    }
}
