using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    GameObject _taget;
    NavMeshAgent _agent;
    Animator _animator;

    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponentInChildren<Animator>();

        _taget = GameObject.Find("Tower");
    }

    void Update()
    {
        _agent.SetDestination(_taget.transform.position);
        _animator.SetFloat("MoveSpeed", 1.0f);
    }
}
