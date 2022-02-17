using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public float Enemy_HP;
    public int Enemy_att;
    public Slider _hpbar;

    Movement _movement = null;
    Attack _attack = null;
    GameObject _target;

    public int EnemyNum;
    public bool _die;
    void Start()
    {
        instance = this;
        _die = false;
        if (EnemyNum == 1) Enemy_HP = 1000.0f + (info.instance._round * 100.0f);
        else Enemy_HP = 200.0f+(info.instance._round*50.0f);
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
            info.instance.Gold(10);
            if(this.tag == "Enemy") Quest.intance._kill++;
            else if(this.tag =="Boss") Quest.intance._bossKill++;

            _die = true;
            Destroy(this.gameObject);
        }

        if (_attack.IsinRange(_target)== false)
        {
            if (EnemyNum == 1) Invoke("EnemyBossRoaring", 5.0f);
            else if(EnemyNum == 0)_movement.Moving();
            //_movement.Moving();
        }
        else
        {
            _movement.MovingEnd();
            _attack.Attacking(_target);
        }
    }

    private void EnemyBossRoaring()
    {
        _movement.Moving();
    }
}
