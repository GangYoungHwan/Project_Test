using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject _EnemyNormal;

    public List<GameObject> _EnemyObjectPool;
    int _count;
    int _dieCount;

    public float _currentTime;
    public int _remainingTime;

    int _round;
    void Start()
    {
        _round = 0;
        _currentTime = 0.0f;
        _remainingTime = 60;
    }
    private void Awake()
    {
        _count = 0;
        _dieCount = 0;
        _EnemyObjectPool = new List<GameObject>();
        StartCoroutine(EnemySpawn());
    }

    void Update()
    {
        if (_remainingTime + 1 < 60)
        {
            _round++;
            _currentTime = 0.0f;
            _remainingTime = 0;
            
        }
        else
        {
            _currentTime += Time.deltaTime;
            _remainingTime = (int)_currentTime % 60;
        }
        if(_count<10)
        {
            Debug.Log("몬스터생성 중단");
        }
    }

    IEnumerator EnemySpawn()
    {
        for (int i = 0; i < _EnemyObjectPool.Count+1; i++)
        {
            GameObject Normal = Instantiate(_EnemyNormal);
            _EnemyObjectPool.Add(Normal);
            _EnemyObjectPool[i].transform.position = this.transform.position;
            _EnemyObjectPool[i].GetComponent<NavMeshAgent>().enabled = true;
            yield return new WaitForSeconds(3.0f);
            _count++;
        }
    }
}
