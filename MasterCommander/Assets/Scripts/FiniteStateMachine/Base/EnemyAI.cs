using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(StateMachine))]
public class EnemyAI : MonoBehaviour
{
    [Header("Hareket Deðiþkenleri")]
    public float speed;

    [Header("Konum Deðiþkenleri")]
    public Transform ownTransform;
    public Transform playerTransform;

    [Header("Component Deðiþkenleri")]
    public StateMachine stateMachine;
    public Stats enemyStats;
    // public Animator animator;
    public MeshRenderer[] tankModelMeshes;
    public EngineSound enemyEngineSound;

    [Header("Referans Deðiþkenleri")]
    public Weapon weapon;
    public EnemyUnit enemyUnit;
    public GameObject silverPrefab;

    [Header("Saldýrý Deðiþkenleri")]
    public GameObject nearestSoldier;

    [Header("State Deðiþkenleri")]
    public EnemyIdleState idleState;
    public EnemyAttackState attackState;
    public EnemyDeadState deadState;

    [Header("State Veri Deðiþkenleri")]
    public IdleStateData idleStateData;
    public AttackStateData attackStateData;
    public DeadStateData deadStateData;

    private void Awake()
    {
        ComponentAttach();
        StateDataVariablesAttach();
        CreateStates();
    }

    private void Start()
    {
        enemyUnit.AddEnemy(this);
        Manager.manager.IncreaseEnemyCount();
        Idle();
    }
    #region Baþlangýç Fonksiyonlarý
    private void ComponentAttach()
    {
        ownTransform = transform;
        stateMachine = GetComponent<StateMachine>();
        weapon = GetComponentInChildren<Weapon>();
        enemyEngineSound = GetComponent<EngineSound>();
        enemyUnit = GetComponentInParent<EnemyUnit>();
        enemyStats = GetComponent<Stats>();
    }

    private void StateDataVariablesAttach()
    {
        idleStateData.attackRadius = attackStateData.attackRadius;
    }
    #endregion


    #region Ýç Fonksiyonlar

    public void GenerateSilver()
    {
        Instantiate(silverPrefab, transform.position, transform.rotation);
    }
    public void DestroyOwnself()
    {
        Destroy(gameObject, 5);
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

    #region Stateleri Oluþturma ve Deðiþtirme

    public void Idle()
    {
        stateMachine.ChangeState(idleState);
    }

    public void Attack()
    {
        stateMachine.ChangeState(attackState);
    }

    public void Dead()
    {
        stateMachine.ChangeState(deadState);
    }


    public void CreateStates()
    {
        NewIdleState();
        NewAttackState();
        NewDeadState();
    }

    public void NewIdleState()
    {
        EnemyIdleState newIdleState = new EnemyIdleState(idleStateData, this);
        idleState = newIdleState;
    }

    public void NewAttackState()
    {
        EnemyAttackState newAttackState = new EnemyAttackState(attackStateData, this);
        attackState = newAttackState;
    }

    public void NewDeadState()
    {
        EnemyDeadState newDeadState = new EnemyDeadState(deadStateData, this);
        deadState = newDeadState;
    }
    #endregion

    #region Editör Kodlarý
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.5f);
        if (attackStateData)
        {
            Gizmos.DrawWireSphere(transform.position, attackStateData.attackRadius);
        }
    }
    #endregion
}
