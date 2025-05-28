using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

public class Use : MonoBehaviour
{
    [SerializeField] private float _range = 3f;

    private bool _hasItem => GetComponent<Grab>().item;
    private RaycastHit _ray => RayCast.InteractRay(_range);

    void Update() => Press();

    private void Press()
    {
        if (IsButtonDown() && !_hasItem) Using();
    }

    private void Using()
    {
        if (!RayItem()) return;
        GetUsed(_ray).Using();
    }

    private bool RayItem()
    {
        if (!_ray.transform) return false;
        if (GetUsed(_ray) == null) return false;

        return true;
    }

    private IUsing GetUsed(RaycastHit ray)
    {
        return ray.transform.gameObject.GetComponent<IUsing>();
    }

    private bool IsButtonDown()
    {
        return Input.GetButtonDown("Use") ||
            TCKInput.GetAction("grubBtn", EActionEvent.Down);
    }
}

public interface IUsing
{
    public void Using();
}
