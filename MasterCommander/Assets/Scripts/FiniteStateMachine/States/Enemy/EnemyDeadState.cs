using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : IState
{
    public EnemyAI enemyAI;
    public EnemyUnit enemyUnit;
    public EnemyDeadState(DeadStateData deadStateData, EnemyAI enemyAI)
    {
        this.enemyAI = enemyAI;
        this.enemyUnit = enemyAI.enemyUnit;
    }
    public void OnStateEnter()
    {
        Debug.Log("Dead State Enter");
        enemyUnit.RemoveEnemy(enemyAI);
        Manager.manager.DecreaseEnemyCount();
        enemyAI.GenerateSilver();
        enemyAI.DestroyOwnself();
        enemyAI.ChangeMaterials();
    }

    public void OnStateExit()
    {
        Debug.Log("Dead State Exit");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log("Dead State FixedUpdate");
    }

    public void OnStateUpdate()
    {
        Debug.Log("Dead State Update");
    }
}