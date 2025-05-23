using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Button;

public class TriggerTag : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private ButtonClickedEvent _eventsEnter = new ButtonClickedEvent();
    [SerializeField] private ButtonClickedEvent _eventsExit = new ButtonClickedEvent();

    public string triggerTag => _tag;

    public void Enter() => _eventsEnter?.Invoke();
    public void Exit() => _eventsExit?.Invoke();
}
