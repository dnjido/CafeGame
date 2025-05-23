using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UseCoffeeMashine : MonoBehaviour, IUsing
{
    [SerializeField] private GameObject[] _flows;
    [SerializeField] private Transform _cupPoint;
    
    private bool _used;
    private GameObject _trigger;

    private GameObject _cup => GetCup();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stop()
    {
        _used = false;
        foreach (GameObject f in _flows) f.SetActive(_used);
    }

    public void Using()
    {
        if (_used || !_cup) return;
        if (_cup.GetComponent<FillFluid>().filled) return;

        _used = true;
        foreach (GameObject f in _flows) f.SetActive(_used);
        _cup.GetComponent<FillFluid>().StartFill(Stop);
    }

    public GameObject GetCup()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_cupPoint.position, .15f);
        return hitColliders.FirstOrDefault(o => o.tag == "Item").gameObject;
    }
}
