using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    public static info instance;
    public int _level;
    public float _time;
    public int _att;
    public int _attspeed;
    public int _gold;
    public int _dia;

    public int _round;

    public int _getGold;
    public int _getDia;
    public int _getExp;

    public Text _goldText;
    public Text _RoundText;
    public Slider _expSlider;

    public Transform _getGoldPos;
    public GameObject _getGoldUI;

    public Transform _getDiaPos;
    public GameObject _getDiaUI;

    public Transform _getExpPos;
    public GameObject _getExpUI;

    public Transform _getLevelUpPos;
    public GameObject _getLevelUpUI;
    void Start()
    {
        instance = this;

        _level = 1;
        //_exp = 0;
        _time = 0.0f;
        _att = 20;
        _attspeed = 1;
        _gold = 100;
        _dia = 0;
    }


    void Update()
    {
        _time += Time.deltaTime;
        //LevelUp();
        _goldText.text = ""+_gold;
        _expSlider.maxValue = 60;
        _expSlider.value = _time%60;
        _RoundText.text = "" + ((int)_time/60%60+1);
        _round = ((int)_time / 60 % 60 + 1);
    }

    //void LevelUp()
    //{
    //    if(_exp >= (_level*50))
    //    {
    //        _level++;
    //        _att++;
    //        _exp = 0;
    //        Instantiate(_getLevelUpUI, _getLevelUpPos.position, Quaternion.identity, GameObject.Find("UI").transform);
    //    }
    //}
    public void Gold(int gold)
    {
        _getGold = gold;
        Instantiate(_getGoldUI, _getGoldPos.position, Quaternion.identity, GameObject.Find("UI").transform);
        _gold += gold;
    }
    public void Dia(int dia)
    {
        _getDia = dia;
        _dia += dia;
        Instantiate(_getDiaUI, _getDiaPos.position, Quaternion.identity, GameObject.Find("UI").transform);
    }
    //public void Exp(int exp)
    //{
    //    _getExp = exp;
    //    _exp += exp;
    //    Instantiate(_getExpUI, _getExpPos.position, Quaternion.identity, GameObject.Find("UI").transform);
    //}
}
