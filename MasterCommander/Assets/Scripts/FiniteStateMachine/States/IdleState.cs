using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : IState
{
    // Hareket
    public float speed;

    // Süre
    public float waitTime;
    public float timer;

    // Konum
    private Transform ownTransform;
    private Transform playerTransform;

    // Component
    public Animator animator;
    public AnimatorControllerParameter[] parameters;

    public NavMeshAgent navMeshAgent;
    public EnemyAI enemyAI;

    // Algýlama
    public float chaseRadius;

    public IdleState(IdleStateData idleStateData)
    {
        this.speed = idleStateData.moveSpeed;
        //this.animator = idleStateData.animator;
        //this.navMeshAgent = idleStateData.navMeshAgent;
        //this.waitTime = idleStateData.waitTime;
        //this.enemyAI = idleStateData.enemyAI;
        //this.ownTransform = idleStateData.ownTransform;
        //this.playerTransform = idleStateData.playerTransform;
        //this.chaseRadius = idleStateData.chaseRadius;
    }

    public void OnStateEnter()
    {
        Debug.Log("Enter Idle State");
        StartTimer();
        ChangeNavMeshAgentSpeed();
        PlayAnimation();
    }


    public void OnStateExit()
    {
        Debug.Log("Exit Idle State");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log("FixedUpdate Idle State");
    }

    public void OnStateUpdate()
    {
        Debug.Log("Update Idle State");
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

        // animator.SetBool(idleAnimVariableName, true);
    }



    private void StartTimer()
    {
        timer = Time.time + waitTime;
    }
}
