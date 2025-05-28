using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapPlace : MonoBehaviour
{
    [SerializeField] private Transform _capParent, _capPoint;
    [SerializeField] private bool _hasCap;
    [SerializeField] private AudioClip _capAudio;

    public bool hasCap => _hasCap;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<TriggerTag>()) return;
        if (other.GetComponent<TriggerTag>().triggerTag != "cap") return;
        Placing(other.gameObject);
    }

    private void Placing(GameObject cap)
    {
        if (cap == null || _hasCap == true) return;
        if (!_capParent.GetComponent<FillFluid>().filled) return;
        //cap.GetComponent<PickUp>().StopTransform();
        FindObjectOfType<Grab>().Drop();
        cap.GetComponent<Outline>().enabled = false;
        _hasCap = true;
        Destroy(cap.GetComponent<Rigidbody>());
        cap.transform.position = _capPoint.position;
        cap.transform.rotation = _capPoint.rotation;
        cap.transform.parent = _capParent;
        GetComponentInParent<AudioSource>().PlayOneShot(_capAudio);
        //Destroy(_capPoint);
    }
}
