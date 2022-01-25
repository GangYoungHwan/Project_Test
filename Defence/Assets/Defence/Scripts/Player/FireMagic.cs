using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagic : MonoBehaviour
{
    float _speed;

    Player _player;
    Transform _target;
    public ParticleSystem _critical;
    void Start()
    {
        _speed = 0.3f;
    }

    void Update()
    {
        if (TargetFind(_target))
        {
            this.transform.LookAt(_target);
            this.transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool TargetFind(Transform Target)
    {
        if (Target != null)
        {
            _target = Target;
            return true;
        }
        else return false;
    }
}
