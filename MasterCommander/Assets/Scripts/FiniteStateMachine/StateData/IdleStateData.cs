using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Idle State Data", menuName = "Finite State Machine / State Data / Idle State Data")]
public class IdleStateData : ScriptableObject
{
    [Header("Hareket Değişkenleri")]
    public float moveSpeed;

    public float rotateSpeed;

    [Header("Konum Değişkenleri")]
    public Transform ownTransform;

    [Header("Süre Değişkenleri")]
    public float waitTime;

    [Header("Saldırı Değişkenleri")]
    [HideInInspector]
    public float attackRadius;

    public LayerMask enemyLayer;
    public LayerMask soldierLayer;

    // [Header("Component Değişkenleri")]
    // public Animator animator;
}
