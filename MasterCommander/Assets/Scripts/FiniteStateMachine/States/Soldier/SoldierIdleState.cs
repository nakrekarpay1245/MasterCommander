using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : IState
{
    // public Animator animator;
    // public AnimatorControllerParameter[] parameters;
    public Stats soldierStats;

    public EngineSound soldierEngineSound;

    public SoldierAI soldierAI;
    public SoldierIdleState(IdleStateData idleStateData, SoldierAI soldierAI)
    {
        this.soldierAI = soldierAI;
        this.soldierStats = soldierAI.soldierStats;
        this.soldierEngineSound = soldierAI.soldierEngineSound;
    }
    public void OnStateEnter()
    {
        Debug.Log("Enter Soldier Idle State");
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
        soldierEngineSound.DecreaseSpeed();

        if (!soldierStats.isAlive)
        {
            soldierAI.Dead();
        }
    }
}
