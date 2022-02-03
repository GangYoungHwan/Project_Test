using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject _EnemyNormal;
    public GameObject _EnemyBoss;

    public bool GameOver = false;
    public float _createTime = 3.0f;
    public float _reSpwanTime = 30.0f;
    
    public int _maxEnemy = 10;
    int EnemyCount = 0;

    public int _round = 1;
    public void Start()
    {
        instance = this;
    }
    private void Awake()
    {
        StartCoroutine(CreateEnemy());
    }

    void Update()
    {

    }
    IEnumerator CreateEnemy()
    {
        while(!GameOver)
        {
            int CreateEnemyCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (CreateEnemyCount > 100) GameOver = true; //100마리되면 게임끝

            if (EnemyCount< _maxEnemy)
            {
                yield return new WaitForSeconds(_createTime);
                Instantiate(_EnemyNormal, this.transform.position, this.transform.rotation);
                _EnemyNormal.GetComponent<NavMeshAgent>().enabled = true;
                EnemyCount++;
            }
            else
            {
                yield return new WaitForSeconds(_reSpwanTime);
                _round++;
                EnemyCount = 0;
            }

            //if(_round == 2)
            //{
            //    yield return new WaitForSeconds(_createTime);
            //    Instantiate(_EnemyBoss, this.transform.position, this.transform.rotation);
            //    _EnemyBoss.GetComponent<NavMeshAgent>().enabled = true;
            //    yield return new WaitForSeconds(_reSpwanTime*2);
            //}
        }
    }
}
