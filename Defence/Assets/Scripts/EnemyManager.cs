using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject _EnemyNormal;

    public List<GameObject> _EnemyObjectPool;
    int _count;
    void Start()
    {
        //_count = 10;
        //_EnemyObjectPool = new List<GameObject>();
    }
    private void Awake()
    {
        _count = 10;
        _EnemyObjectPool = new List<GameObject>();
        StartCoroutine(EnemySpawn());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {
        //yield return new WaitForSeconds(1.0f);
        for(int i=0; i< _count; i++)
        {
            GameObject Normal = Instantiate(_EnemyNormal);
            _EnemyObjectPool.Add(Normal);
            _EnemyObjectPool[i].transform.position = this.transform.position;
            _EnemyObjectPool[i].GetComponent<NavMeshAgent>().enabled = true;
            yield return new WaitForSeconds(3.0f);
        }
    }
}
