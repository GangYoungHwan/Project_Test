using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    float _Dmg;

    public GameObject _damageText;
    public Transform _damagePos;
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
            TakeDamage(_Dmg,other.transform.FindChild("DmgPos"));
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage,Transform pos)
    {
        GameObject hudText = Instantiate(_damageText);
        hudText.transform.position = pos.position;
        hudText.GetComponent<DmgText>().damage = damage;
    }
}
