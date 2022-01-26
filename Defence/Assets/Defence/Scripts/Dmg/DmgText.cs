﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgText : MonoBehaviour
{
    private float _moveSpeed;
    private float _alphaSpeed;
    private float _destroyTime;
    TextMeshPro text;
    Color _alpha;
    public float damage;
    
    void Start()
    {
        _moveSpeed = 2.0f;
        _alphaSpeed = 2.0f;
        _destroyTime = 2.0f;

        text = GetComponent<TextMeshPro>();
        _alpha = text.color;
        text.text = damage.ToString();
        Invoke("DestroyObject", _destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _alpha.a = Mathf.Lerp(_alpha.a, 0, Time.deltaTime * _alphaSpeed);
        text.color = _alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
