using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject _target;
    Animator _animator;
    Movement _movement = null;
    public float _Distance = 5.0f;
    float dis;

    float _attackDelay = 2.0f;
    float _lastAttack = 0.0f;
    void Start()
    {
        _target = GameObject.Find("Tower");
        _animator = this.GetComponent<Animator>();
        _movement = this.GetComponent<Movement>();
    }

    void Update()
    {
        _lastAttack += Time.deltaTime;
        if (IsinRange() == false)
        {
            _movement.Moving();
        }
        else
        {
            _movement.MovingEnd();
            Attacking();
        }
    }

    private void Attacking()
    {
        this.transform.LookAt(_target.transform);

        if (_lastAttack < _attackDelay)
        {
            _animator.ResetTrigger("Attack");
            _animator.SetTrigger("StopAttack");
        }
        else
        {
            _animator.ResetTrigger("StopAttack");
            _animator.SetTrigger("Attack");
            _lastAttack = 0.0f;
        }
    }

    private bool IsinRange()
    {
        dis = Vector3.Distance(_target.transform.position, this.transform.position);
        return dis < _Distance;
    }
}
