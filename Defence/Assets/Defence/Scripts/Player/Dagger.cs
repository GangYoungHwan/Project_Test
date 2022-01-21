using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public float _speed = 1.0f;
    Transform _target;

    void Update()
    {
        if (TargetFind(_target))
        {
            this.transform.LookAt(_target);
            this.transform.position = Vector3.MoveTowards(_target.position, _target.position, Time.deltaTime * _speed);
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
