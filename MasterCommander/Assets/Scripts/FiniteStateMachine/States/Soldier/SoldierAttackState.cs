using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : IState
{
    // Hareket
    public float rotateSpeed;

    // Component
    // public Animator animator;
    // public AnimatorControllerParameter[] parameters;
    public Stats soldierStats;

    public EngineSound soldierEngineSound;

    public SoldierAI soldierAI;

    // Referans
    public Weapon weapon;

    // Konum
    public Transform ownTransform;

    // Algýlama
    public float attackRadius;

    // Saldýrý
    public float attackTime;
    public float nextAttackTime;

    private GameObject nearestEnemy;
    public SoldierAttackState(AttackStateData attackStateData, SoldierAI soldierAI)
    {
        this.rotateSpeed = attackStateData.rotateSpeed;
        this.soldierAI = soldierAI;
        this.soldierStats = soldierAI.soldierStats;
        this.ownTransform = soldierAI.ownTransform;
        this.attackRadius = attackStateData.attackRadius;
        this.attackTime = attackStateData.attackTime;
        this.weapon = soldierAI.weapon;
        this.soldierEngineSound = soldierAI.soldierEngineSound;
    }
    public void OnStateEnter()
    {
        Debug.Log("Enter Attack State");
    }

    public void OnStateExit()
    {
        Debug.Log("Exit Attack State");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log("FixedUpdate Attack State");
    }

    public void OnStateUpdate()
    {
        soldierEngineSound.DecreaseSpeed();

        nearestEnemy = soldierAI.nearestEnemy;
        Debug.Log("Update Attack State");
        if (nearestEnemy)
        {
            if (nearestEnemy.GetComponent<EnemyAI>().enemyStats.isAlive)
            {
                LookToNearestEnemy();
                if (Time.time > nextAttackTime)
                {
                    nextAttackTime = Time.time + attackTime +
                        Random.Range(attackTime / 10, attackTime / 15);

                    weapon.Fire();
                }
            }
            else
            {
                nearestEnemy = soldierAI.nearestEnemy;
            }
        }

        else
        {
            //Buraya süreye baðlý bir fonksiyon ekleyelim yoksa bu mallar iþi doðru yapamayacak
            soldierAI.Chase();
        }

        if (!soldierStats.isAlive)
        {
            soldierAI.Dead();
        }
    }

    private void LookToNearestEnemy()
    {
        Quaternion nearestEnemyRotation =
            Quaternion.LookRotation(nearestEnemy.transform.position - ownTransform.position);

        ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation,
            nearestEnemyRotation, rotateSpeed * 100 * Time.deltaTime);
    }
}
