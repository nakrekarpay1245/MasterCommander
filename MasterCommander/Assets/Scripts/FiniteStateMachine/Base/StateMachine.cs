using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour
{
    public IState currentState;

    public void ChangeState(IState iState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = iState;
        currentState.OnStateEnter();
    }

    public void Update()
    {
        if (currentState != null)
            currentState.OnStateUpdate();
    }

    public void FixedUpdate()
    {
        if (currentState != null)
            currentState.OnStateFixedUpdate();
    }
}
