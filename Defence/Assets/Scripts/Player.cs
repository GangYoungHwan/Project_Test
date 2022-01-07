using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Player : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;

    GameObject[] _target;
    public float _Distance = 15.0f;

    float _attackDelay = 2.0f;
    float _lastAttack = 0.0f;
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        _lastAttack += Time.deltaTime;
        //if (IsinRange()==false)
        //{
        //    UpdateAnimator();
        //    StopAttack();
        //}
        //else
        //{
        //    Attack();
        //}
        _target = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < _target.Length; i++)
        {
            if (Vector3.Distance(_target[i].transform.position, this.transform.position) < _Distance)//사정거리
            {
                
                if (_lastAttack < _attackDelay)
                {
                    _agent.isStopped = false;
                    _animator.ResetTrigger("Attack");
                    _animator.SetTrigger("StopAttack");
                }
                else
                {
                    _agent.isStopped = true;
                    this.transform.LookAt(_target[i].transform);
                    _animator.ResetTrigger("StopAttack");
                    _animator.SetTrigger("Attack");
                    _lastAttack = 0.0f;
                }

            }
            else
            {
                UpdateAnimator();
                StopAttack();
            }
        }
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _animator.SetFloat("MoveSpeed", local.z);
    }

    //void Attack()
    //{
    //    _target = GameObject.FindWithTag("Enemy");
    //
    //    if (_lastAttack < _attackDelay)
    //    {
    //        _agent.isStopped = false;
    //        _animator.ResetTrigger("Attack");
    //        _animator.SetTrigger("StopAttack");
    //    }
    //    else
    //    {
    //        _agent.isStopped = true;
    //        this.transform.LookAt(_target.transform);
    //        _animator.ResetTrigger("StopAttack");
    //        _animator.SetTrigger("Attack");
    //        _lastAttack = 0.0f;
    //    }
    //}

    void StopAttack()
    {
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
    }

    //private bool IsinRange()
    //{
    //    _target = GameObject.FindGameObjectsWithTag("Enemy");
    //    for (int i=0; i<_target.Length;i++)
    //    {
    //        if(Vector3.Distance(_target[i].transform.position, this.transform.position) < _Distance)
    //        {
    //            Debug.Log("target");
    //
    //        }
    //        else
    //        {
    //
    //        }
    //    }
    //    //return Vector3.Distance(_target.transform.position, this.transform.position) < _Distance;
    //
    //}
}
