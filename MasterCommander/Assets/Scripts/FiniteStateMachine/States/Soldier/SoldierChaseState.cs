using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : IState
{
    public ChaseStateData chaseStateData;

    public Transform ownTransform;
    public Transform chasePointTransform;

    public float moveSpeed;
    public float rotateSpeed;

    // Component
    // public Animator animator;
    // public AnimatorControllerParameter[] parameters;
    public Stats soldierStats;

    public EngineSound soldierEngineSound;

    public SoldierAI soldierAI;

    // Saldýrý
    public float attackRadius;
    public LayerMask enemyLayer;
    public GameObject nearestEnemy;


    public SoldierChaseState(ChaseStateData chaseStateData, SoldierAI soldierAI)
    {
        this.chaseStateData = chaseStateData;
        this.ownTransform = soldierAI.ownTransform;
        this.moveSpeed = chaseStateData.moveSpeed;
        this.rotateSpeed = chaseStateData.rotateSpeed;
        this.soldierAI = soldierAI;
        this.soldierStats = soldierAI.soldierStats;
        this.attackRadius = chaseStateData.attackRadius;
        this.enemyLayer = chaseStateData.enemyLayer;
        this.soldierEngineSound = soldierAI.soldierEngineSound;
    }
    public void OnStateEnter()
    {
        Debug.Log("Enter Chase State");
    }

    public void OnStateExit()
    {
        Debug.Log("Exit Chase State");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log("FixedUpdate Chase State");
    }

    public void OnStateUpdate()
    {
        Debug.Log("Update Chase State");
        nearestEnemy = soldierAI.nearestEnemy;
        CheckEnemiesOnAttackArea();
        MoveToChasePoint();

        if (!soldierStats.isAlive)
        {
            soldierAI.Dead();
        }
    }

    private void MoveToChasePoint()
    {
        if (soldierAI.chasePointTransform)
        {
            chasePointTransform = soldierAI.chasePointTransform;

            if (Vector3.Distance(ownTransform.position,
                chasePointTransform.position) > attackRadius)
            {
                Vector3 chasePoint = new Vector3(chasePointTransform.position.x,
                    ownTransform.position.y, chasePointTransform.position.z);

                ownTransform.position = Vector3.MoveTowards(ownTransform.position,
                    chasePoint, Time.deltaTime * moveSpeed);
                soldierEngineSound.IncreaseSpeed();
                LookToChasePoint();
            }
            else
            {
                soldierAI.Attack();
            }
        }
    }

    private void LookToChasePoint()
    {
        Vector3 chasePointPosition = new Vector3(chasePointTransform.position.x,
            ownTransform.position.y, chasePointTransform.position.z);

        Quaternion chasePointRotation =
            Quaternion.LookRotation(chasePointPosition - ownTransform.position);

        ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation,
            chasePointRotation, rotateSpeed * 100 * Time.deltaTime);
    }

    public void CheckEnemiesOnAttackArea()
    {
        Collider[] enemies =
            Physics.OverlapSphere(ownTransform.position, attackRadius, enemyLayer);

        if (enemies.Length > 0)
        {
            nearestEnemy = enemies[0].gameObject;
            // Debug.Log("enemies[i].gameObject : " + enemies[0].gameObject.name);
            soldierAI.nearestEnemy = nearestEnemy;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (Vector3.Distance(ownTransform.position, enemies[i].transform.position) <
                    Vector3.Distance(ownTransform.position, nearestEnemy.transform.position))
                {
                    nearestEnemy = enemies[i].gameObject;
                    Debug.Log("enemies[i].gameObject : " + enemies[i].gameObject.name);
                }
            }

            if (nearestEnemy.GetComponent<EnemyAI>().enemyStats.isAlive)
            {
                soldierAI.nearestEnemy = nearestEnemy;
                soldierAI.Attack();
            }
        }
    }
}
