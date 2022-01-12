using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : MonoBehaviour
{
    int EnemyNormal_HP;
    void Start()
    {
        EnemyNormal_HP = 100;
    }

    void Update()
    {
        if(EnemyNormal_HP ==0)
        {
            Destroy(this.gameObject);
        }
    }
}
