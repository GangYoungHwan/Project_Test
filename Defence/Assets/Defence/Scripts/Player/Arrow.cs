using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float _speed;

    Player _player;
    Transform _target;
    void Start()
    {
        _speed = 1.0f;
        GameObject obj = GameObject.FindWithTag("Archer");
        if (obj != null)
        {
            _player = obj.GetComponent<Player>();
            _target = _player._target.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            this.transform.LookAt(_target);
            this.transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }
}
