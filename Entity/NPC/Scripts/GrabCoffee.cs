using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCoffee : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.GetComponentInChildren<CapPlace>().hasCap) return;
        //Destroy(collision.gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CapPlace>();
        FindFirstObjectByType<Grab>().Throw();
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.transform.SetParent(grabPoint, true);
        collision.transform.position = grabPoint.position;
        collision.transform.rotation = grabPoint.rotation;
        
        //Destroy(GetComponent<Rigidbody>());

        GetComponent<Animator>().Play("Drinking");
    }
}
