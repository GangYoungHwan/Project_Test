using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public Transform _spwanPos;

    public GameObject[] _unit;

    public ParticleSystem _spwanEffect;
    void Start()
    {
        _spwanEffect.Stop();
        
    }

   
    void Update()
    {
        
    }

    public void UnitSpwan(int num)
    {
        _spwanEffect.Play();
        StartCoroutine(Test(num));
        //Instantiate(_unit[num], _spwanPos.position, _spwanPos.rotation);
    }

    IEnumerator Test(int num)
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(_unit[num], _spwanPos.position, _spwanPos.rotation);
        StopCoroutine(Test(num));
    }
}
