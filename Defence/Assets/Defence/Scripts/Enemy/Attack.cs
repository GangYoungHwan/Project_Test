using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator _animator;
    public float _Distance = 5.0f;
    float dis;

    float _attackDelay = 2.0f;
    float _lastAttack = 0.0f;
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (this.gameObject == null) return;
        _lastAttack += Time.deltaTime;
    }

    public void Attacking(GameObject target)
    {
        this.transform.LookAt(target.transform);

        if (_lastAttack < _attackDelay)
        {
            _animator.ResetTrigger("Attack");
            _animator.SetTrigger("StopAttack");
        }
        else
        {
            _animator.ResetTrigger("StopAttack");
            _animator.SetTrigger("Attack");
            Damage(Enemy.instance.Enemy_att);
            _lastAttack = 0.0f;
        }
    }

    public bool IsinRange(GameObject target)
    {
        dis = Vector3.Distance(target.transform.position, this.transform.position);
        return dis < _Distance;
    }

    public void Damage(int att)
    {
        TowerManager.instance.Tower_HP -= att;
    }
}
