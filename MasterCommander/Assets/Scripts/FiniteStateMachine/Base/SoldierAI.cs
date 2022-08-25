using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class SoldierAI : MonoBehaviour
{
    [Header("Hareket De�i�kenleri")]
    public float speed;

    [Header("Konum De�i�kenleri")]
    public Transform ownTransform;
    public Transform chasePointTransform;

    [Header("Component De�i�kenleri")]
    public StateMachine stateMachine;
    public Stats soldierStats;
    // public Animator animator;
    public MeshRenderer[] tankModelMeshes;
    public EngineSound soldierEngineSound;

    [Header("Referans De�i�kenleri")]
    public Weapon weapon;

    public GameObject silverPrefab;

    [Header("Sald�r� De�i�kenleri")]
    public GameObject nearestEnemy;

    [Header("State De�i�kenleri")]
    public SoldierIdleState idleState;
    public SoldierChaseState chaseState;
    public SoldierAttackState attackState;
    public SoldierDeadState deadState;
    public LineUpState lineUpState;

    [Header("State Veri De�i�kenleri")]
    public IdleStateData idleStateData;
    public ChaseStateData chaseStateData;
    public AttackStateData attackStateData;
    public DeadStateData deadStateData;
    public LineUpStateData lineUpStateData;

    private void Awake()
    {
        ComponentAttach();
        StateDataVariablesAttach();
        CreateStates();
    }
    private void Start()
    {
        LineUp();

        Commander.commander.AddSoldier(this);
    }

    #region Ba�lang�� Fonskiyonlar�

    private void ComponentAttach()
    {
        stateMachine = GetComponent<StateMachine>();
        // animator = GetComponentInChildren<Animator>();
        soldierStats = GetComponent<Stats>();
        ownTransform = transform;
        weapon = GetComponentInChildren<Weapon>();
        soldierEngineSound = GetComponent<EngineSound>();
    }

    private void StateDataVariablesAttach()
    {
        chaseStateData.attackRadius = attackStateData.attackRadius;
    }
    #endregion

    #region �� Fonksiyonlar
    public void ChangeChasePointTranform(Transform _chasePoint)
    {
        chasePointTransform = _chasePoint;
        Chase();
    }

    public void GenerateSilver()
    {
        Instantiate(silverPrefab, transform.position, transform.rotation);
    }

    public void DestroyOwnself()
    {
        Destroy(gameObject, 1);
    }
    public void ChangeMaterials()
    {
        foreach (MeshRenderer tankModelMesh in tankModelMeshes)
        {
            foreach (Material material in tankModelMesh.materials)
            {
                material.color = Color.gray;
            }
        }
    }
    #endregion

    #region Stateleri Olu�turma ve De�i�tirme

    public void Idle()
    {
        stateMachine.ChangeState(idleState);
    }

    public void Chase()
    {
        stateMachine.ChangeState(chaseState);
    }

    public void Attack()
    {
        stateMachine.ChangeState(attackState);
    }

    public void Dead()
    {
        stateMachine.ChangeState(deadState);
    }
    public void LineUp()
    {
        stateMachine.ChangeState(lineUpState);
    }


    public void CreateStates()
    {
        NewIdleState();
        NewChaseState();
        NewAttackState();
        NewDeadState();
        NewLineUpState();
    }

    public void NewIdleState()
    {
        SoldierIdleState newIdleState = new SoldierIdleState(idleStateData, this);
        idleState = newIdleState;
    }


    public void NewChaseState()
    {
        SoldierChaseState newChaseState = new SoldierChaseState(chaseStateData, this);
        chaseState = newChaseState;
    }

    public void NewAttackState()
    {
        SoldierAttackState newAttackState = new SoldierAttackState(attackStateData, this);
        attackState = newAttackState;
    }


    public void NewDeadState()
    {
        SoldierDeadState newDeadState = new SoldierDeadState(deadStateData, this);
        deadState = newDeadState;
    }

    public void NewLineUpState()
    {
        LineUpState newLineUpState = new LineUpState(lineUpStateData, this);
        lineUpState = newLineUpState;
    }
    #endregion

    #region Edit�r Kodlar�
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 255, 255, 0.1f);
        if (attackStateData)
        {
            Gizmos.DrawWireSphere(transform.position, attackStateData.attackRadius);
        }
    }
    #endregion
}

