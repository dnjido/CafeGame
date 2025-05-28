using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavigate : MonoBehaviour
{
    public Action CompleteEvent;

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

        Vector3 direction = (_lookPoint.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

        if (_moved && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _moved = false;
            CompleteEvent?.Invoke();
        }
    }
}
