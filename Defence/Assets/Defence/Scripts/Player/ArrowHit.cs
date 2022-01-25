using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    int _Dmg;
    void Start()
    {
        //GameObject obj = GameObject.FindWithTag("Archer");
        //_Dmg = obj.GetComponent<Player>().Damage;
        _Dmg = Player.instance.ArcherDamage;
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
