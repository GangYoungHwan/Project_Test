﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public int Enemy_HP;
    public int Enemy_att;
    public Slider _hpbar;

    Movement _movement = null;
    Attack _attack = null;
    GameObject _target;
    void Start()
    {
        instance = this;
        Enemy_HP = 100+(EnemyManager.instance._round*20);
        Enemy_att = Random.Range(10 * EnemyManager.instance._round, 20 * EnemyManager.instance._round);
        _hpbar = this.transform.GetChild(1).transform.GetChild(0).GetComponent<Slider>();
        _hpbar.maxValue = Enemy_HP;

        _movement = this.GetComponent<Movement>();
        _attack = this.GetComponent<Attack>();
        _target = GameObject.Find("Tower");
    }

    void Update()
    {
        _hpbar.value = Enemy_HP;
        if (Enemy_HP <= 0)
        {
            Destroy(this.gameObject);
        }

        if (_attack.IsinRange(_target)== false)
        {
            _movement.Moving();
        }
        else
        {
            _movement.MovingEnd();
            _attack.Attacking(_target);
        }
    }
}