using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Chase State Data", menuName = "Finite State Machine / State Data / Chase State Data")]

public class ChaseStateData : ScriptableObject
{
    [Header("Hareket Değişkenleri")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Saldırı Değişkenleri")]
    public float attackRadius;

    public LayerMask enemyLayer;
    public LayerMask soldierLayer;
}
