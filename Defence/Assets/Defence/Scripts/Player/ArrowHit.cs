using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    int _Dmg;
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("Player");//나중에 아쳐로 변경하기
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
