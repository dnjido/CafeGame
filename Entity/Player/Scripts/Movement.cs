using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController _characterController => GetComponent<CharacterController>();

    // Update is called once per frame
    void FixedUpdate() => Move();

    private void Move()
    {
        if (_characterController == null) return;

        if (MoveVector() == Vector2.zero) return;

        Vector3 move = transform.right * MoveVector().x + transform.forward * MoveVector().y;

        _characterController.Move(move * speed * Time.deltaTime);
    }

    private Vector2 MoveVector()
    {
        Vector2 vector = Vector2.zero;
        vector.x += Input.GetAxis("Horizontal");
        vector.y += Input.GetAxis("Vertical");

        try
        {
            vector.x += TCKInput.GetAxis("Joystick").x;
            vector.y += TCKInput.GetAxis("Joystick").y;
        }
        catch { }

        return vector;
    }
}
