using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeadState : IState
{
    // public Animator animator;
    // public AnimatorControllerParameter[] parameters;
    public Stats soldierStats;

    public EngineSound soldierEngineSound;

    public SoldierAI soldierAI;
    public SoldierDeadState(DeadStateData deadStateData, SoldierAI soldierAI)
    {
        this.soldierAI = soldierAI;
        this.soldierStats = soldierAI.soldierStats;
        this.soldierEngineSound = soldierAI.soldierEngineSound;
    }
    public void OnStateEnter()
    {
        Debug.Log("Enter Dead State");
        Commander.commander.RemoveSoldier(soldierAI);
        soldierAI.GenerateSilver();
        soldierAI.DestroyOwnself();
        soldierAI.ChangeMaterials();
    }

    public void OnStateExit()
    {
        Debug.Log("Exit Dead State");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log("FixedUpdate Dead State");
    }

    public void OnStateUpdate()
    {
        Debug.Log("Update Dead State");
        soldierEngineSound.DecreaseSpeed();
    }
}
