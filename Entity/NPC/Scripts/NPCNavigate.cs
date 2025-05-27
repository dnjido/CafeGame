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
        //_agent.updateRotation = false;
        _moved = true;
        //transform.DOLookAt(_lookPoint.transform.position, 2f).SetEase(Ease.InOutQuad).OnComplete(() => { _agent.updateRotation = true; });
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Velocity", _agent.velocity.magnitude);

        Vector3 turnTowardNavSteeringTarget = _agent.steeringTarget;

        Vector3 direction = (_lookPoint.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    void LookAtTarget()
    {
        _moved = false;
        transform.DOLookAt(_lookPoint.transform.position, 1f).SetEase(Ease.InOutQuad);
    }
}
