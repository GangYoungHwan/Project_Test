using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float _speed = 0.3f;
    Transform _target;

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
