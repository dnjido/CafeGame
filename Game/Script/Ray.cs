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
}
