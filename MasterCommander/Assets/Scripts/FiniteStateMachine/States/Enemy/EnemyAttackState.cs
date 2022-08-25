using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IState
{
    // Hareket
    public float rotateSpeed;

    // Component
    // public Animator animator;
    // public AnimatorControllerParameter[] parameters;
    public Stats enemyStats;

    public EnemyAI enemyAI;

    // Referans
    public Weapon weapon;

    // Konum
    public Transform ownTransform;

    // Algýlama
    public float attackRadius;

    // Saldýrý
    public float attackTime;
    public float nextAttackTime;

    private GameObject nearestSoldier;
    public EnemyAttackState(AttackStateData attackStateData, EnemyAI enemyAI)
    {
        this.rotateSpeed = attackStateData.rotateSpeed;
        // this.animator = enemyAI.animator;
        this.enemyStats = enemyAI.enemyStats;
        this.enemyAI = enemyAI;
        this.ownTransform = enemyAI.ownTransform;
        this.attackRadius = attackStateData.attackRadius;
        this.attackTime = attackStateData.attackTime;
        this.weapon = enemyAI.weapon;

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
        Debug.Log("Update Attack State");
        nearestSoldier = enemyAI.nearestSoldier;
        if (nearestSoldier)
        {
            Debug.Log("Nearest Soldier: " + nearestSoldier);
            LookToNearestSoldier();
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackTime +
                    Random.Range(attackTime / 10, attackTime / 15);
                weapon.Fire();
            }
        }
        else
        {
            enemyAI.Idle();
        }

        if (!enemyStats.isAlive)
        {
            enemyAI.Dead();
        }
    }

    private void LookToNearestSoldier()
    {
        Quaternion nearestSoldierRotation =
            Quaternion.LookRotation(nearestSoldier.transform.position - ownTransform.position);

        ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation,
            nearestSoldierRotation, rotateSpeed * 100 * Time.deltaTime);
    }
}
