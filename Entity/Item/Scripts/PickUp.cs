using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 2.0f;
    private GameObject _point;
    private bool _start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_start) Transform();
    }

    // Update is called once per frame
    public void Transform()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _point.transform.localPosition, moveSpeed * Time.deltaTime);

        //Quaternion targetRotation = new Quaternion(0,0,0,0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void StartTransform(GameObject point)
    {
        _point = point;
        _start = true;
        //GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.SetParent(_point.transform);
    }

    public void StopTransform()
    {
        _point = null;
        _start = false;
        //GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        transform.SetParent(null);
    }
}
