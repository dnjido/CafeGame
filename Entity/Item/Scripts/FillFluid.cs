using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FillFluid : MonoBehaviour
{
    [SerializeField] private float _fillAmount, _fillSpeed;
    [SerializeField] private GameObject _fillMesh;
    [SerializeField] private Transform _fillPointBotton, _fillPointUp;
    private bool _filling;

    void Start()
    {
        StartFill();
    }

    public void StartFill()
    {
        _fillMesh.SetActive(true);
        _filling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_filling) Fill();
    }

    private void Fill()
    {
        Debug.Log("FILLING");
        _fillMesh.transform.localPosition = Vector3.Lerp(_fillMesh.transform.localPosition, _fillPointUp.localPosition, _fillSpeed * Time.deltaTime);
        _fillMesh.transform.localScale = Vector3.Lerp(_fillMesh.transform.localScale, _fillPointUp.localScale, _fillSpeed * Time.deltaTime);
        //if(_fillMesh.transform.localScale.x >= _fillPointUp.localScale.x) _filling = false;
    }
}
