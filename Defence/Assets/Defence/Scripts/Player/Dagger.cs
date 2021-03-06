using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public float _speed = 0.3f;
    Transform _target;
    public ParticleSystem _critical;

    public float _Dmg;
    public bool Critical;
    public GameObject _damageText;
    public GameObject _criticalDamageText;
    void Update()
    {
        if (TargetFind(_target))
        {
            this.transform.LookAt(_target);
            this.transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //if (_target.GetComponent<Enemy>()._die) Destroy(this.gameObject);
    }

    public bool TargetFind(Transform Target)
    {
        if (Target != null)
        {
            _target = Target;
            return true;
        }
        else return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.GetComponent<HitEffect>().hitbloodEffect();
            other.GetComponent<Enemy>().Enemy_HP -= _Dmg;
            TakeDamage(_Dmg, other.transform.Find("DmgPos"));
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage, Transform pos)
    {
        Vector3 _pos = pos.position;
        _pos.y = 1;
        if (Player.instance != null)
        {
            if (Critical)
            {
                GameObject hudText = Instantiate(_criticalDamageText);
                hudText.transform.position = _pos;
                hudText.GetComponent<DmgText>().damage = damage;
            }
            else
            {
                GameObject hudText = Instantiate(_damageText);
                hudText.transform.position = _pos;
                hudText.GetComponent<DmgText>().damage = damage;
            }
        }
    }
}
