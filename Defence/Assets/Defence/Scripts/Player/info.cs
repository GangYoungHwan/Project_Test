using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public static info instance;
    public int _level;
    public int _exp;
    public int _att;
    public int _attspeed;
    public int _gold;
    public int _dia;
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
        
    }

    void LevelUp()
    {

    }
}
