using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    // Hareket
    public float rotateSpeed;

    // Component
    // public Animator animator;
    // public AnimatorControllerParameter[] parameters;
    public Stats enemyStats;

    public EnemyAI enemyAI;

    // Konum
    public Transform ownTransform;

    // Algýlama
    public float attackRadius;
    public LayerMask soldierLayer;

    private GameObject nearestSoldier;

    public EnemyIdleState(IdleStateData idleStateData, EnemyAI enemyAI)
    {
        this.rotateSpeed = idleStateData.rotateSpeed;
        // this.animator = idleStateData.animator;
        this.enemyStats = enemyAI.enemyStats;
        this.enemyAI = enemyAI;
        this.ownTransform = enemyAI.ownTransform;
        this.attackRadius = idleStateData.attackRadius;
        this.soldierLayer = idleStateData.soldierLayer;
    }

    public void OnStateEnter()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Enter Idle State");
    }

    public void OnStateExit()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Exit Idle State");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy FixedUpdate Idle State");
    }

    public void OnStateUpdate()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Update Idle State");
        CheckSoldiersOnAttackArea();
        if (!enemyStats.isAlive)
        {
            enemyAI.Dead();
        }
    }

    public void CheckSoldiersOnAttackArea()
    {
        Collider[] soldiers =
            Physics.OverlapSphere(ownTransform.position, attackRadius, soldierLayer);

        if (soldiers.Length > 0)
        {
            nearestSoldier = soldiers[0].gameObject;
            // Debug.Log("soldiers[i].gameObject : " + soldiers[0].gameObject.name);
            enemyAI.nearestSoldier = nearestSoldier;
            for (int i = 0; i < soldiers.Length; i++)
            {
                if (Vector3.Distance(ownTransform.position, soldiers[i].transform.position) <
                    Vector3.Distance(ownTransform.position, nearestSoldier.transform.position))
                {
                    nearestSoldier = soldiers[i].gameObject;
                    // Debug.Log("soldiers[i].gameObject : " + soldiers[i].gameObject.name);
                }
            }
            enemyAI.nearestSoldier = nearestSoldier;
            enemyAI.Attack();
        }
    }
}
