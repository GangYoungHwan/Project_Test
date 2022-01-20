using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public Transform _spwanPos;

    public GameObject[] _unit;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void UnitSpwan(int num)
    {
        Instantiate(_unit[num], _spwanPos.position, _spwanPos.rotation);
    }
}
