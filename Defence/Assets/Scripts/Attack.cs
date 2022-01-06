using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject _taget;
    public float _Distance = 4.0f;
    float dis;
    void Start()
    {
        _taget = GameObject.Find("Tower");
    }

    void Update()
    {
        dis = Vector3.Distance(_taget.transform.position, this.transform.position);
        if(dis< _Distance)
        {
            Debug.Log("공격중");
        }
    }
}
