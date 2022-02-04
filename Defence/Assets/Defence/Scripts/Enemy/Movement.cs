using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    GameObject _target;
    NavMeshAgent _agent;
    Animator _animator;

    int way;
    bool wayon;

    void Start()
    {
        way = 0;
        _agent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponentInChildren<Animator>();
        _target = GameObject.Find("Way1End");
        //if (_target != null) _agent.SetDestination(_target.transform.position);
        _animator.SetFloat("MoveSpeed", 1.0f);
    }

    void Update()
    {


    }

    public void Moving()
    {
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
        
        if (_agent != null && _agent.enabled)
        {
            if (_agent.remainingDistance < 0.3f && !wayon)
            {
                way++;
                switch (way)
                {
                    case 1:
                        _target = GameObject.Find("Way2End");
                        break;
                    case 2:
                        _target = GameObject.Find("Way3End");
                        break;
                    case 3:
                        _target = GameObject.Find("WayEnd");
                        break;
                    case 4:
                        _target = GameObject.Find("Tower");
                        break;
                    case 5:
                        break;
                }
                if (_target != null)
                {
                    _animator.SetFloat("MoveSpeed", 1.0f);
                    _agent.isStopped = false;
                    _agent.SetDestination(_target.transform.position);
                }
                wayon = true;
            }
            else wayon = false;
        }
    }

    public void MovingEnd()
    {
        if (_agent != null && _agent.enabled)
        {
            _animator.SetFloat("MoveSpeed",0.0f);
            _agent.isStopped = true;
        }
    }
}
