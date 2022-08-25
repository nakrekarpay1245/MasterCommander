using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Attack State Data", menuName = "Finite State Machine / State Data / Attack State Data")]

public class AttackStateData : ScriptableObject
{
    [Header("Hareket Deðiþkenleri")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Konum Deðiþkenleri")]
    public Transform ownTransform;

    //[Header("Component Deðiþkenleri")]
    //public Animator animator;

    [Header("Algýlama Deðiþkenleri")]
    public float attackRadius;

    [Header("Saldýrý Deðiþkenleri")]
    public float attackTime;
}
