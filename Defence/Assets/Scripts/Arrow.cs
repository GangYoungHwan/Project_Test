using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float _speed;
    void Start()
    {
        _speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NewPosition = this.transform.forward*_speed*Time.deltaTime;
        this.transform.position = this.transform.position+NewPosition;
    }
}
