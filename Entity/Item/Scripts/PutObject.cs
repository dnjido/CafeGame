using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObject : MonoBehaviour
{
    private Storage _storage;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.GetComponent<PickUp>()) return;

        other.GetComponent<PickUp>().StopTransform();
        Destroy(other.gameObject);

        _storage.Add();
    }
}
