using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    static public Quest intance;
    public int _kill = 0;
    public int _bossKill = 0;
    public int _archerSpwan = 0;
    public int _ninjaSpwan = 0;
    public int _wizardSpwan = 0;
    void Start()
    {
        intance = this;
    }

    void Update()
    {
        
    }
}
