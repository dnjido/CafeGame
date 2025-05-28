using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class SetGrabPoint : MonoBehaviour
{
    Transform _parent => transform.parent;
    Vector3 _origin => Camera.main.transform.position; // The position of the object
    Vector3 _direction => Camera.main.transform.forward;
    Vector3 _offset => Camera.main.transform.up * -0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Vector3.zero;
        RaycastHit hit;

        if (Physics.Raycast(_origin, _direction + _offset, out hit, 1, ~(1 << 2))) // 100f is the max distance
        {
            point = hit.point;
        }
        else point = _parent.position;

        transform.position = point;// - Camera.main.transform.up * -0.05f;
    }
}
