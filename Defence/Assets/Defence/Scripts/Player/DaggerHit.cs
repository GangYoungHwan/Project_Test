﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerHit : MonoBehaviour
{
    float _Dmg;
    void Start()
    {
        //GameObject obj = GameObject.FindWithTag("Ninja");
        //_Dmg = obj.GetComponent<Player>().Damage;
        _Dmg = Player.instance.NinjaDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<HitEffect>().hitbloodEffect();
            other.GetComponent<Enemy>().Enemy_HP -= _Dmg;
            Destroy(this.gameObject);
        }
    }
}
