using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Attack State Data", menuName = "Finite State Machine / State Data / Attack State Data")]

public class AttackStateData : ScriptableObject
{
    [Header("Hareket Değişkenleri")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Konum Değişkenleri")]
    public Transform ownTransform;

    //[Header("Component Değişkenleri")]
    //public Animator animator;

    [Header("Algılama Değişkenleri")]
    public float attackRadius;

    [Header("Saldırı Değişkenleri")]
    public float attackTime;
}
