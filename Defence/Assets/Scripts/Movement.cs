using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Transform _taget;
    NavMeshAgent _agent;
    Animator _animator;

    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _agent.SetDestination(_taget.position);
        _animator.SetFloat("MoveSpeed", 1.0f);
    }
}
