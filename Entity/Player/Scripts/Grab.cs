using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TouchControlsKit;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private float _range = 3f;
    [SerializeField] private Transform _point;

    private GameObject _item;
    private RaycastHit _ray => RayCast.InteractRay(_range);

    // Update is called once per frame
    void Update() => Press();

    private void Press()
    {
        if (IsButtonDown()) Throw();

        if (Input.GetMouseButtonDown(0)) Pick();
    }

    private void Pick()
    {
        if (!RayItem()) return;

        _item = GetPickUp(_ray).gameObject;
        GetPickUp(_ray).StartTransform(_point);
    }

    private void Throw()
    {
        if (!_item) return;

        _item.GetComponent<PickUp>().StopTransform();
        _item = null;
    }

    private bool RayItem()
    {
        if (!_ray.transform) return false;
        if (!GetPickUp(_ray)) return false;

        return true;
    }

    private PickUp GetPickUp(RaycastHit ray)
    {
        return ray.transform.gameObject.GetComponent<PickUp>();
    }

    private bool IsButtonDown()
    {
        return Input.GetButtonDown("Use") || 
            TCKInput.GetAction("grubBtn", EActionEvent.Down);
    }
}
