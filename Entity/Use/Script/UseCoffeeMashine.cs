using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseCoffeeMashine : MonoBehaviour
{
    [SerializeField] private GameObject[] flows;
    [SerializeField] private bool used;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        used = !used;
        foreach (GameObject f in flows) f.SetActive(used);
    }
}
