using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerHit : MonoBehaviour
{
    int _Dmg;
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("Ninja");
        _Dmg = obj.GetComponent<Player>().Damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Enemy_HP -= _Dmg;
            Destroy(this.gameObject);
        }
    }
}
