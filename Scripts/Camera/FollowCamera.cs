using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform _target;
    public float _distance = 5.0f;
    public float heightoffset = 3.0f;
    public float cameraDelay = 0.02f;

    void Update()
    {
        Vector3 followPos = _target.position - _target.forward * _distance;

        followPos.y += heightoffset;
        transform.position += (followPos - transform.position) * cameraDelay;

        transform.LookAt(_target.transform);
    }
}
