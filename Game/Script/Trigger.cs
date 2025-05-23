using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private string _tag;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<TriggerTag>()) return;
        if (other.GetComponent<TriggerTag>().triggerTag != _tag) return;
        other.GetComponent<TriggerTag>()?.Enter();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<TriggerTag>()) return;
        if (other.GetComponent<TriggerTag>().triggerTag != _tag) return;
        other.GetComponent<TriggerTag>()?.Exit();
    }
}
