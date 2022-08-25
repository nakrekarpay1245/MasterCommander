using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public List<EnemyAI> enemyList;

    public bool isAlive;

    private void Start()
    {
        EnemyUnitManager.unitManager.AddUnit(this);
    }

    private void Update()
    {
        //buraya sonra o düþmanalrýn canlý olup olmadýkalrýna dair kontrol ekleyeceðiz
        isAlive = enemyList.Count > 0;

        if (!isAlive)
        {
            EnemyUnitManager.unitManager.RemoveUnit(this);
            Destroy(gameObject);
        }
    }

    public EnemyAI GetEnemy()
    {
        return enemyList[Random.Range(0, enemyList.Count)];
    }

    public void AddEnemy(EnemyAI enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(EnemyAI enemy)
    {
        enemyList.Remove(enemy);
    }
}
