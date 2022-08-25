using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    // Hareket
    public float speed;

    // Component
    public Animator animator;
    public AnimatorControllerParameter[] parameters;
    public NavMeshAgent navMeshAgent;
    public EnemyAI enemyAI;

    // Konum
    private Transform ownTransform;
    private Transform playerTransform;

    // Algýlama
    public float chaseRadius;
    public float attackRadius;

    public ChaseState(ChaseStateData chaseStateData)
    {
        //this.speed = chaseStateData.speed;
        //this.animator = chaseStateData.animator;
        //this.navMeshAgent = chaseStateData.navMeshAgent;
        //this.enemyAI = chaseStateData.enemyAI;
        //this.ownTransform = chaseStateData.ownTransform;
        //this.playerTransform = chaseStateData.playerTransform;
        //this.chaseRadius = chaseStateData.chaseRadius;
        //this.attackRadius = chaseStateData.attackRadius;
    }

    public void OnStateEnter()
    {
        Debug.Log("Enter Chase State");
        ChangeNavMeshAgentSpeed();
        PlayAnimation();
    }

    private void ChangeNavMeshAgentSpeed()
    {
        navMeshAgent.speed = speed;
    }

    private void PlayAnimation()
    {
        parameters = animator.parameters;

        foreach (AnimatorControllerParameter parameter in parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                animator.SetBool(parameter.name, false);
            }
        }

        animator.SetBool("isWalk", true);
        animator.SetBool("isRun", true);
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
        FollowToPlayer();
        DetectToPlayer();
    }

    private void FollowToPlayer()
    {
        if (Vector3.Distance(ownTransform.position, playerTransform.position) >
                                            navMeshAgent.stoppingDistance + 1)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }
    private void DetectToPlayer()
    {
        if (Vector3.Distance(ownTransform.position, playerTransform.position) > chaseRadius)
        {
            enemyAI.Idle();
        }

        if (Vector3.Distance(ownTransform.position, playerTransform.position) < attackRadius)
        {
            enemyAI.Attack();
        }
    }
}

