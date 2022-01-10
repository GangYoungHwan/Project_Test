using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Player : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    public float _Distance = 15.0f;

    List<GameObject> FoundObjects;
    GameObject _target;
    float shortDis;

    float _attackDelay = 2.0f;
    float _lastAttack = 0.0f;
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _lastAttack += Time.deltaTime;
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);
        _target = FoundObjects[0];

        foreach(GameObject found in FoundObjects)
        {
            float dis = Vector3.Distance(gameObject.transform.position, found.transform.position);
            if(dis < shortDis)
            {
                _target = found;
                shortDis = dis;
            }
        }

        if (Vector3.Distance(this.transform.position, _target.transform.position) < _Distance)//사정거리
        {
            
            if (_lastAttack < _attackDelay)
            {
                _agent.isStopped = false;
                _animator.ResetTrigger("Attack");
                _animator.SetTrigger("StopAttack");
                UpdateAnimator();
            }
            else
            {
                _agent.isStopped = true;
                this.transform.LookAt(_target.transform);
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
    private void UpdateAnimator()
    {
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _animator.SetFloat("MoveSpeed", local.z);
    }

    void StopAttack()
    {
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
    }
}
