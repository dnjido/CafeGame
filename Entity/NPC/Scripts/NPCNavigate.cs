using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavigate : MonoBehaviour
{
    [SerializeField] private Transform _movePoint, _lookPoint;
    private bool _moved;

    private NavMeshAgent _agent => GetComponent<NavMeshAgent>();

    // Start is called before the first frame update
    void Start()
    {
        _agent.SetDestination(_movePoint.position);
        _moved = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Velocity", _agent.velocity.magnitude);
        if (_moved && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            LookAtTarget();
        }
    }

    void LookAtTarget()
    {
        _moved = false;
        transform.DOLookAt(_lookPoint.transform.position, 1f).SetEase(Ease.InOutQuad);
    }
}
