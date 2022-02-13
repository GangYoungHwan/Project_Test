using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLv : MonoBehaviour
{
    public ParticleSystem Lv_1;
    public ParticleSystem Lv_2;
    public ParticleSystem Lv_3;
    public ParticleSystem Lv_4;
    public ParticleSystem Lv_5;
    public ParticleSystem Lv_5_1;
    
    public void Level_1()
    {
        Lv_1.gameObject.SetActive(true);
        Lv_2.gameObject.SetActive(false);
        Lv_3.gameObject.SetActive(false);
        Lv_4.gameObject.SetActive(false);
        Lv_5.gameObject.SetActive(false);
        Lv_5_1.gameObject.SetActive(false);
    }
    public void Level_2()
    {
        Lv_1.gameObject.SetActive(false);
        Lv_2.gameObject.SetActive(true);
        Lv_3.gameObject.SetActive(false);
        Lv_4.gameObject.SetActive(false);
        Lv_5.gameObject.SetActive(false);
        Lv_5_1.gameObject.SetActive(false);
    }
    public void Level_3()
    {
        Lv_1.gameObject.SetActive(false);
        Lv_2.gameObject.SetActive(false);
        Lv_3.gameObject.SetActive(true);
        Lv_4.gameObject.SetActive(false);
        Lv_5.gameObject.SetActive(false);
        Lv_5_1.gameObject.SetActive(false);
    }
    public void Level_4()
    {
        Lv_1.gameObject.SetActive(false);
        Lv_2.gameObject.SetActive(false);
        Lv_3.gameObject.SetActive(false);
        Lv_4.gameObject.SetActive(true);
        Lv_5.gameObject.SetActive(false);
        Lv_5_1.gameObject.SetActive(false);
    }
    public void Level_5()
    {
        Lv_1.gameObject.SetActive(false);
        Lv_2.gameObject.SetActive(false);
        Lv_3.gameObject.SetActive(false);
        Lv_4.gameObject.SetActive(false);
        Lv_5.gameObject.SetActive(true);
        Lv_5_1.gameObject.SetActive(true);
    }
}
