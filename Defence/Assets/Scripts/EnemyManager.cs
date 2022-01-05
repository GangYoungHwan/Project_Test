using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject _EnemyNormal;

    public List<GameObject> _EnemyObjectPool;
    int _count;
    void Start()
    {
        _count = 0;
        _EnemyObjectPool = new List<GameObject>();
        GameObject Normal = Instantiate(_EnemyNormal);
        _EnemyObjectPool.Add(Normal);
        _EnemyObjectPool[_count].transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
