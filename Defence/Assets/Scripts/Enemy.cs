using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Enemy_HP;
    public Slider _hpbar;
    void Start()
    {
        Enemy_HP = 100;
        _hpbar = this.transform.GetChild(1).transform.GetChild(0).GetComponent<Slider>();
        _hpbar.maxValue = Enemy_HP;
    }

    void Update()
    {
        _hpbar.value = Enemy_HP;
        if (Enemy_HP == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
