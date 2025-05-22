using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

public class Viewing : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    private bool isMobile;
    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update() => Look();

    private void Look()
    {
        Vector2 mouse = LookVector() * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouse.x);

        _xRotation -= mouse.y;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    private Vector2 LookVector()
    {
        Vector2 vector = Vector2.zero;
        if (!isMobile)
        {
            vector.x += Input.GetAxis("Mouse X");
            vector.y += Input.GetAxis("Mouse Y");
        }

        try
        {
            vector.x += TCKInput.GetAxis("Touchpad").x;
            vector.y += TCKInput.GetAxis("Touchpad").y;
        }
        catch { }

        return vector;
    }

    public void SetMobile(bool mobile) => 
        isMobile = mobile;
}
