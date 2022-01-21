using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    public static info instance;
    public int _level;
    public int _exp;
    public int _att;
    public int _attspeed;
    public int _gold;
    public int _dia;

    public Text _goldText;
    public Text _levelText;
    public Slider _expSlider;
    void Start()
    {
        instance = this;

        _level = 1;
        _exp = 0;
        _att = 20;
        _attspeed = 1;
        _gold = 0;
        _dia = 0;
    }


    void Update()
    {
        LevelUp();
        _goldText.text = ""+_gold;
        _levelText.text = "" + _level;
        _expSlider.maxValue = _level * 50;
        _expSlider.value = _exp;
    }

    void LevelUp()
    {
        if(_exp >= (_level*50))
        {
            _level++;
            _att++;
            _exp = 0;
        }
    }
    public void Gold(int gold)
    {
        _gold += gold;
    }

    public void Exp(int exp)
    {
        _exp += exp;
    }
}
