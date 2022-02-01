using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    public float _Dmg;

    public GameObject _damageText;
    public Transform _damagePos;
    void Start()
    {
        //GameObject obj = GameObject.FindWithTag("Archer");
        //_Dmg = obj.GetComponent<Player>().Damage;
        _Dmg = Random.Range((int)Player.instance.ArcherDamage/2, (int)Player.instance.ArcherDamage);
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
        if (Player.instance != null)
        {
            int _rand = Random.Range(0, 100);
            int _critical = Player.instance.ArcherCritical;

            if (_rand < _critical)
            {
                hudText.transform.GetChild(0).GetComponent<CriticalHit>().CriticalHiting();
                hudText.GetComponent<DmgText>().damage = damage * Player.instance.ArcherCriticalDmg;
            }
            else
            {
                hudText.GetComponent<DmgText>().damage = damage;
            }
        }
    }
}
