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
    float _attackSpeed = 1.0f;
    public int AttackSpeed = 1;

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
    }

    void Update()
    {
        MovingCheck();
        if (moving)//이동할때
        {
            UpdateAnimator();
        }
        else//이동을 멈출때
        {
            Targeting();//타겟팅 찾기
            if (_target != null)//이동을 멈추고 타겟팅이 있다면?
            {
                if (IsinRange() == true)//타겟팅이 사거리안에 있다면?
                {
                    AttackSpeeding(AttackSpeed);//공격속도조절
                    _lastAttack += Time.deltaTime;
                    if (_lastAttack < _attackDelay) UpdateAnimator();//공격딜레이
                    else AttackTrigger();//공격딜레이가 끝났다면 공격
                }
                else UpdateAnimator();//타겟팅이 사거리 없다면?
            }
            else UpdateAnimator();// 이동을 멈추고 타겟팅이 없다면?
        }
    }
    private void UpdateAnimator()
    {
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _animator.SetFloat("MoveSpeed", local.z);
    }

    void StopAttack(float delay)
    {
        _agent.isStopped = false;
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
        _lastAttack = delay;
    }

    void ArrowAttack()
    {
        _animator.SetFloat("MoveSpeed", 0);
        GameObject arrow = Instantiate(_waepon);
        _arr.Add(arrow);
        arrow.transform.position = _firePosition.position;
        _lastAttack = 0.0f;
    }

    void DaggerAttack()
    {
        _animator.SetFloat("MoveSpeed", 0);
        GameObject Dagger = Instantiate(_waepon);
        _arr.Add(Dagger);
        Dagger.transform.position = _firePosition.position;
        _lastAttack = 0.0f;
    }

    void FireMagicAttack()
    {
        _animator.SetFloat("MoveSpeed", 0);
        GameObject FireMagic = Instantiate(_waepon);
        _arr.Add(FireMagic);
        FireMagic.transform.position = _firePosition.position;
        _lastAttack = 0.0f;
    }

    void AttackTrigger()
    {
        this.transform.LookAt(_target.transform);
        _animator.ResetTrigger("StopAttack");
        _animator.SetTrigger("Attack");
    }
    public void Targeting()
    {
        //==========================================================
        GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
        if (obj == null) return; //오류보기싫어서 넣음
        //==========================================================
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
        if (_target == null) return false;
        float dis = Vector3.Distance(_target.transform.position, this.transform.position);
        return dis < _Distance;
    }

    public void AttackSpeeding(int speed)
    {
        switch(speed)
        {
            case 1:
                _attackSpeed = 1.0f;
                _attackDelay = 1.0f;
                break;
            case 2:
                _attackSpeed = 1.5f;
                _attackDelay = 0.5f;
                break;
            case 3:
                _attackSpeed = 2.0f;
                _attackDelay = 0.1f;
                break;

        }

        _animator.SetFloat("AttackSpeed", _attackSpeed);
    }

    public void MovingCheck()
    {
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        if (local.z == 0) moving = false;
        else moving = true;
    }
}
