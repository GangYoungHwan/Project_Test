using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    GameObject _taget;
    NavMeshAgent _agent;
    Animator _animator;

    int way;
    void Start()
    {
        way = 1;
        _agent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponentInChildren<Animator>();
        _taget = GameObject.Find("Way1End");
    }

    void Update()
    {
        if(_agent.remainingDistance<0.3f)
        {
            switch (way)
            {
                case 1:
                    _taget = GameObject.Find("Way2End");
                    way =2;
                    Debug.Log("Way2이동");
                    break;
                case 2:
                    _taget = GameObject.Find("Way3End");
                    way = 3;
                    Debug.Log("Way3이동");
                    break;
                case 3:
                    _taget = GameObject.Find("WayEnd");
                    way = 4;
                    Debug.Log("WayEnd이동");
                    break;
                case 4:
                    _taget = GameObject.Find("Tower");
                    Debug.Log("타워이동");
                    break;
            }
            if (_taget != null) _agent.SetDestination(_taget.transform.position);
            _animator.SetFloat("MoveSpeed", 1.0f);
        }
    }
}
