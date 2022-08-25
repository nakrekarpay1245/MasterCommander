using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Idle State Data", menuName = "Finite State Machine / State Data / Idle State Data")]
public class IdleStateData : ScriptableObject
{
    [Header("Hareket Deðiþkenleri")]
    public float moveSpeed;

    public float rotateSpeed;

    [Header("Konum Deðiþkenleri")]
    public Transform ownTransform;

    [Header("Süre Deðiþkenleri")]
    public float waitTime;

    [Header("Saldýrý Deðiþkenleri")]
    [HideInInspector]
    public float attackRadius;

    public LayerMask enemyLayer;
    public LayerMask soldierLayer;

    // [Header("Component Deðiþkenleri")]
    // public Animator animator;
}
