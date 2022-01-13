﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Player : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    public float _Distance = 15.0f;

    List<GameObject> FoundObjects;
    public GameObject _target;
    float shortDis;

    float _attackDelay;
    float _lastAttack = 2.1f;
    public float _attackSpeed = 1.0f;

    public GameObject _waepon;
    public Transform _firePosition;
    List<GameObject> _arr;
    bool moving;
    bool Attacking;

    public int Damage;
    void Start()
    {
        moving = false;
        Damage = 20;
        _animator = this.GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
        _arr = new List<GameObject>();

        if (this.gameObject.tag == "NinJa") _attackDelay = 1.5f;
        else _attackDelay = 1.0f;
    }

    void Update()
    {
        //_lastAttack += Time.deltaTime;
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        if (FoundObjects.Count > 0)
        {
            shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);
            _target = FoundObjects[0];
        }

        foreach (GameObject found in FoundObjects)
        {
            float dis = Vector3.Distance(gameObject.transform.position, found.transform.position);
            if (dis < shortDis)
            {
                _target = found;
                shortDis = dis;
            }
        }

        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        if (local.z == 0) moving = false;
        else moving = true;

        if(moving)
        {
            UpdateAnimator();
        }
        else
        {
            if(IsinRange()==true)
            {
                _lastAttack += Time.deltaTime;
                if (_lastAttack < _attackDelay)
                {
                    AttackTrigger();
    
                }
                else
                {
                    if (this.gameObject.tag == "Archer") ArrowAttack();
                    if (this.gameObject.tag == "Ninja") DaggerAttack();
                    _lastAttack = 0.0f;
                }
            }
            else
            {
                UpdateAnimator();
            }
        }
    }
    private void UpdateAnimator()
    {
        StopAttack();
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _animator.SetFloat("MoveSpeed", local.z);
    }

    void StopAttack()
    {
        _agent.isStopped = false;
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
    }

    void ArrowAttack()
    {
        StopAttack();
        _animator.SetFloat("MoveSpeed", 0);
        GameObject arrow = Instantiate(_waepon);
        _arr.Add(arrow);
        arrow.transform.position = _firePosition.position;
    }

    void DaggerAttack()
    {
        StopAttack();
        _animator.SetFloat("MoveSpeed", 0);
        GameObject Dagger = Instantiate(_waepon);
        _arr.Add(Dagger);
        Dagger.transform.position = _firePosition.position;
    }
    void AttackTrigger()
    {
        _agent.isStopped = true;
        this.transform.LookAt(_target.transform);
        _animator.ResetTrigger("StopAttack");
        _animator.SetTrigger("Attack");
        _agent.isStopped = false;
        Attacking = false;
    }
    void Targeting()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);
        _target = FoundObjects[0];

        foreach (GameObject found in FoundObjects)
        {
            float dis = Vector3.Distance(gameObject.transform.position, found.transform.position);
            if (dis < shortDis)
            {
                _target = found;
                shortDis = dis;
            }
        }
    }

    public bool IsinRange()
    {
        float dis = Vector3.Distance(_target.transform.position, this.transform.position);
        return dis < _Distance;
    }
}