using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlacingItem : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
    private bool _canPlace;

    protected virtual void Start()
    {
        GetComponent<PickUp>().PutEvent += Placing;
    }

    protected virtual void Placing()
    {
        if (!_canPlace) return;
        transform.position = _position;
        transform.eulerAngles = _rotation;
    }

    public void Enter() => _canPlace = true;
    public void Exit() => _canPlace = false;
}
