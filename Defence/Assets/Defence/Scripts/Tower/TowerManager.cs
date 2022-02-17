using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public int Tower_HP = 1000;
    public Slider _hpbar;
    public bool GameOver = false;
    void Start()
    {
        instance = this;
        _hpbar = this.transform.GetChild(6).transform.GetChild(0).GetComponent<Slider>();
        _hpbar.maxValue = Tower_HP;
    }

    void Update()
    {
        _hpbar.value = Tower_HP;
        if (Tower_HP < 0)
        {
            SceneManagerS.instance.TitleScene();
            GameOver = true;
        }
    }
}
