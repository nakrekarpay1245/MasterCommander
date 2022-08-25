using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Commander : MonoBehaviour
{
    // public TextMeshProUGUI attackText;
    public GameObject attackButton;

    [SerializeField]
    private List<SoldierAI> soldierList;

    public bool isAttack;
    public bool canAttack;

    public EnemyUnit attackUnit;

    public static Commander commander;
    private void Awake()
    {
        if (!commander)
        {
            commander = this;
        }
    }

    public void AddSoldier(SoldierAI _soldier)
    {
        soldierList.Add(_soldier);
    }

    public void RemoveSoldier(SoldierAI _soldier)
    {
        soldierList.Remove(_soldier);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !isAttack && canAttack)
        //{
        //    Attack();
        //}

        attackButton.gameObject.SetActive(canAttack && !isAttack);

        if (isAttack)
        {
            if (!attackUnit.isAlive)
            {
                if (!Manager.manager.isAllEnemiesDied)
                {
                    GetEnemyUnit();
                    StartCoroutine(AttackCoroutine());
                }
                else
                {
                    isAttack = false;
                    StartCoroutine(IdleCoroutine());
                }
            }
        }

        if (soldierList.Count <= 0)
        {
            isAttack = false;
        }
    }

    public void AttackButton()
    {
        if (!isAttack && canAttack)
        {
            Attack();
        }
    }
    public void AttackButtonActive()
    {
        canAttack = true;
    }
    public void AttackButtonDeactive()
    {
        canAttack = false;
    }

    public void Attack()
    {
        if (!isAttack)
        {
            isAttack = true;
            GetEnemyUnit();
            StartCoroutine(AttackCoroutine());
        }
    }

    public void GetEnemyUnit()
    {
        attackUnit = EnemyUnitManager.unitManager.GetEnemyUnit();
        // Debug.Log("Enemy Unit: " + EnemyUnitManager.unitManager.GetEnemyUnit().name);
    }

    public IEnumerator AttackCoroutine()
    {
        LineUpManager.lineUpManager.ClearLineUpPositions();
        Debug.Log("Attack Coroutine");
        while (isAttack)
        {
            Debug.Log("Attack Coroutine While");

            for (int i = 0; i < soldierList.Count; i++)
            {
                Debug.Log("Attack Point : " + attackUnit.transform.name);

                soldierList[i].ChangeChasePointTranform(attackUnit.GetEnemy().transform);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator IdleCoroutine()
    {
        // Debug.Log("Idle Coroutine");
        while (!isAttack)
        {
            // Debug.Log("Idle Coroutine While");

            for (int i = 0; i < soldierList.Count; i++)
            {
                soldierList[i].Idle();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}