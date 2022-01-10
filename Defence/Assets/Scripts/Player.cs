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
    public GameObject _target;
    float shortDis;

    float _attackDelay = 1.0f;
    float _lastAttack = 0.0f;

    public GameObject _arrow;
    public Transform _firePosition;
    List<GameObject> _arr;
    bool moving;
    bool arrowAttacking;

    void Start()
    {
        moving = false;
        _animator = this.GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
        _arr = new List<GameObject>();
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
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        if (local.z > 0) moving = true;
        else moving = false;

        if (!moving)
        {
            if (Vector3.Distance(this.transform.position, _target.transform.position) < _Distance)//사정거리
            {

                if (_lastAttack < _attackDelay)
                {
                    _agent.isStopped = true;
                    this.transform.LookAt(_target.transform);
                    _animator.ResetTrigger("StopAttack");
                    _animator.SetTrigger("Attack");
                    if (arrowAttacking) ArrowAttack();
                    _agent.isStopped = false;
                }
                else
                {
                    _animator.ResetTrigger("Attack");
                    _animator.SetTrigger("StopAttack");
                    UpdateAnimator();
                    arrowAttacking = true;
                    _lastAttack = 0.0f;
                }

            }
            else
            {
                StopAttack();
                UpdateAnimator();
            }
        }
        else
        {
            StopAttack();
            UpdateAnimator();
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
        _agent.isStopped = false;
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
    }

    void ArrowAttack()
    {
        GameObject arrow = Instantiate(_arrow);
        _arr.Add(arrow);
        arrow.transform.position = _firePosition.position;
        arrowAttacking = false;
    }
}
