using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicHit : MonoBehaviour
{
    float _Dmg;
    public GameObject _damageText;
    void Start()
    {
        //GameObject obj = GameObject.FindWithTag("Wizard");
        //_Dmg = obj.GetComponent<Player>().Damage;
        _Dmg = Player.instance.WizardDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Enemy_HP -= _Dmg;
            other.GetComponent<HitEffect>().hitFireEffect();
            TakeDamage(_Dmg, other.transform.FindChild("DmgPos"));
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage, Transform pos)
    {
        GameObject hudText = Instantiate(_damageText);
        hudText.transform.position = pos.position;
        hudText.GetComponent<DmgText>().damage = damage;
    }
}
