using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public Transform _spwanPos;

    public GameObject[] _unit;

    private List<GameObject> _spwanUnit = new List<GameObject>();
    void Start()
    {

    }

   
    void Update()
    {
        
    }

    public void UnitSpwan(int num)
    {
        //GameObject obj = Instantiate(_unit[num], _spwanPos.position, _spwanPos.rotation);
        Instantiate(_unit[num], _spwanPos.position, _spwanPos.rotation);
        //_spwanUnit.Add(obj);
    }
}
