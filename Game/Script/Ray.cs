using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RayCast
{
    public static RaycastHit RayHit(float range)
    {
        RaycastHit hitInfo;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayOrigin, out hitInfo, range);
        return hitInfo;
    }

    public static RaycastHit InteractRay(float range)
    {
        RaycastHit hitInfo;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayOrigin, out hitInfo, range, 1 << 3);
        return hitInfo;
    }
}
