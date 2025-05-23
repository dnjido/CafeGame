using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInArea : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;
    
    public void AddObject(GameObject obj)
    {
        _objects.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {
        _objects.Remove(obj);
    }
}
