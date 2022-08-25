using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitManager : MonoBehaviour
{
    public List<EnemyUnit> enemyUnits;

    public static EnemyUnitManager unitManager;
    private void Awake()
    {
        if (!unitManager)
        {
            unitManager = this;
        }
    }

    public EnemyUnit GetEnemyUnit()
    {
        if (enemyUnits.Count > 0)
        {
            if (enemyUnits[Random.Range(0, enemyUnits.Count)].isAlive)
            {
                return enemyUnits[Random.Range(0, enemyUnits.Count)];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public void AddUnit(EnemyUnit unit)
    {
        enemyUnits.Add(unit);
    }

    public void RemoveUnit(EnemyUnit unit)
    {
        enemyUnits.Remove(unit);

        if (enemyUnits.Count <= 0)
        {
            Manager.manager.AllEnemiesDied();
        }
    }
}
