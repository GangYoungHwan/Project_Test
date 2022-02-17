using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quest : MonoBehaviour
{
    static public Quest intance;
    public int _kill = 0;
    public int _bossKill = 0;
    public int _archerSpwan = 0;
    public int _ninjaSpwan = 0;
    public int _wizardSpwan = 0;

    public Text _killText;
    public Text _archerSpwanText;
    public Text _ninjaSpwanText;
    public Text _wizardSpwanText;
    public Text _bossKillText;
    public int _killcount;
    public int _bossKillcount;
    public int _archerSpwancount;
    public int _ninjaSpwancount;
    public int _wizardSpwancount;
    void Start()
    {
        _killcount = 3;
        _bossKillcount = 1;
        _archerSpwancount = 3;
        _ninjaSpwancount = 3;
        _wizardSpwancount = 3;
        intance = this;
    }

    void Update()
    {
        _killText.text = "적 " + _killcount + "마리 처치";
        _bossKillText.text = "보스처치";
        _archerSpwanText.text = "아처 " + _archerSpwancount + "번 소환";
        _ninjaSpwanText.text = "닌자 " + _ninjaSpwancount + "번 소환";
        _wizardSpwanText.text = "위자드 " + _wizardSpwancount + "번 소환";
        if (_kill == _killcount)
        {
            info.instance.Gold(100);
            _killcount *= 3;
        }
        else if (_bossKill == _bossKillcount)
        {
            info.instance.Dia(3);
            _bossKillcount++;
            
        }
        else if(_archerSpwan == _archerSpwancount)
        {
            info.instance.Gold(30);
            _archerSpwancount *= 3;
            Debug.Log("아처");
        }
        else if (_ninjaSpwan == _ninjaSpwancount)
        {
            info.instance.Gold(30);
            _ninjaSpwancount *= 3;
            Debug.Log("닌자");
        }
        else if (_wizardSpwan == _wizardSpwancount)
        {
            info.instance.Gold(30);
            _wizardSpwancount *= 3;
            Debug.Log("위자드");
        }
    }
}
