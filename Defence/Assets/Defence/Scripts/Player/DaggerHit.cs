using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerHit : MonoBehaviour
{
    float _Dmg;
    public GameObject _damageText;
    void Start()
    {
        //GameObject obj = GameObject.FindWithTag("Ninja");
        //_Dmg = obj.GetComponent<Player>().Damage;
        _Dmg = Random.Range((int)Player.instance.NinjaDamage/2, (int)Player.instance.NinjaDamage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<HitEffect>().hitbloodEffect();
            other.GetComponent<Enemy>().Enemy_HP -= _Dmg;
            TakeDamage(_Dmg, other.transform.Find("DmgPos"));
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage, Transform pos)
    {
        GameObject hudText = Instantiate(_damageText);

        Vector3 _pos = pos.position;
        _pos.y = 1;
        hudText.transform.position = _pos;

        hudText.GetComponentInChildren<DmgText>().damage = damage;
    }
}
