using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 0)] // 1
public class GameEvent : ScriptableObject 
{
    private List<GameEventListener> listeners = new List<GameEventListener>(); // 3

    public void Raise() // 4
    {
        for (int i = listeners.Count - 1; i >= 0; i--) // 5
        {
            listeners[i].OnEventRaised(); // 6
        }
    }

    public void RegisterListener(GameEventListener listener) // 7
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) // 8
    {
        listeners.Remove(listener);
    }
}
