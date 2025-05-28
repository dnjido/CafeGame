using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCoffee : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private GameObject _moneyEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.GetComponentInChildren<CapPlace>().hasCap) return;

        GameObject.FindGameObjectWithTag("Player").GetComponent<CapPlace>();
        FindFirstObjectByType<Grab>().Throw();
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.transform.SetParent(grabPoint, true);
        collision.transform.position = grabPoint.position;
        collision.transform.rotation = grabPoint.rotation;

        GameObject effect = Instantiate(_moneyEffect, collision.transform.position, _moneyEffect.transform.rotation);
        effect.transform.DOMoveY(effect.transform.position.y + 1, 1f).OnComplete(() => { RemoveEffect(effect); });

        GetComponent<Animator>().Play("Drinking");
        GetComponent<Animator>().speed = 0;

        collision.gameObject.GetComponent<Outline>().enabled = false;
        GetComponent<Outline>().enabled = false;
    }

    private void RemoveEffect(GameObject effect)
    {
        Destroy(effect);
        GetComponent<Animator>().speed = 1;
    }
}
