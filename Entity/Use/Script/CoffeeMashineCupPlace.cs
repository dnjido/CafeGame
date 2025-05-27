using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMashineCupPlace : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;
    [SerializeField] private GameObject _currentCup, _enterCup;
    [SerializeField] private AudioClip _placeAudio;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<TriggerTag>()) return;
        if (other.GetComponent<TriggerTag>().triggerTag != "Cup") return;
        if (_currentCup) return;
        _enterCup = other.gameObject;
        _enterCup.GetComponent<PickUp>().PutEvent += PlaceCup;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<TriggerTag>()) return;
        if (other.GetComponent<TriggerTag>().triggerTag != "Cup") return;
        try { _enterCup.GetComponent<PickUp>().PutEvent -= PlaceCup; } catch { }  
        if (_currentCup == other.gameObject) _currentCup = null;
        other.GetComponent<TriggerTag>()?.Exit();
        _enterCup = null;
    }

    private void PlaceCup()
    {
        _currentCup = _enterCup;
        try { _enterCup.GetComponent<PickUp>().PutEvent -= PlaceCup; } catch { }
        _enterCup = null;
        _currentCup.transform.position = _placePoint.position;
        _currentCup.transform.rotation = _placePoint.rotation;
        GetComponent<AudioSource>().PlayOneShot(_placeAudio);
    }
}
