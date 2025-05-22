using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileDetect : MonoBehaviour
{
    [SerializeField] private bool test;
    private Viewing _viewing;

    private void Init(Viewing viewing) =>
        _viewing = viewing;

    // Start is called before the first frame update
    void Start()
    {
        if(!IsMobile() && !test) Cursor.lockState = CursorLockMode.Locked;
        if(!IsMobile() && !test) gameObject.SetActive(false);
        if(IsMobile() || test) _viewing.SetMobile(true);
    }

    private bool IsMobile() => 
        Application.platform == RuntimePlatform.Android ||
               Application.platform == RuntimePlatform.IPhonePlayer;
}
