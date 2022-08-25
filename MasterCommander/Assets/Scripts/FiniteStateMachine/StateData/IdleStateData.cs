using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Idle State Data", menuName = "Finite State Machine / State Data / Idle State Data")]
public class IdleStateData : ScriptableObject
{
    [Header("Hareket De�i�kenleri")]
    public float moveSpeed;

    public float rotateSpeed;

    [Header("Konum De�i�kenleri")]
    public Transform ownTransform;

    [Header("S�re De�i�kenleri")]
    public float waitTime;

    [Header("Sald�r� De�i�kenleri")]
    [HideInInspector]
    public float attackRadius;

    public LayerMask enemyLayer;
    public LayerMask soldierLayer;

    // [Header("Component De�i�kenleri")]
    // public Animator animator;
}
