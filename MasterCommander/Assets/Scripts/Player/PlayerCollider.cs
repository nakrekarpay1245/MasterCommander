using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Silver"))
        {
            StackManager.stack.AddSilver(other.gameObject);
        }

        if (other.gameObject.CompareTag("CommanderAttackArea"))
        {
            Commander.commander.AttackButtonActive();
        }

        if (other.gameObject.CompareTag("LevelEndArea"))
        {
            Manager.manager.CompleteLevel();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            // Debug.Log("Buy Area");
            other.gameObject.GetComponent<BuyArea>().Buy();
        }

        if (other.gameObject.CompareTag("LevelUpArea"))
        {
            // Debug.Log("Level Up Area");
            other.gameObject.GetComponent<LevelUpArea>().LevelUp();
        }

        if (other.gameObject.CompareTag("CommanderAttackArea"))
        {
            Commander.commander.AttackButtonActive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            other.gameObject.GetComponent<BuyArea>().NotBuy();
        }

        if (other.gameObject.CompareTag("LevelUpArea"))
        {
            // Debug.Log("Level Up Area");
            other.gameObject.GetComponent<LevelUpArea>().NotLevelUp();
        }

        if (other.gameObject.CompareTag("CommanderAttackArea"))
        {
            Commander.commander.AttackButtonDeactive();
        }
    }
}
