using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    GameObject _target;
    void Start()
    {
        _target = GameObject.Find("hpbarf");
    }
    void Update()
    {
        this.transform.forward = _target.transform.forward;
    }
}
