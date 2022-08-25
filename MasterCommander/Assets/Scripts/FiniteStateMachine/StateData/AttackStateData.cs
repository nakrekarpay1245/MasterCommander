using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Attack State Data", menuName = "Finite State Machine / State Data / Attack State Data")]

public class AttackStateData : ScriptableObject
{
    [Header("Hareket De�i�kenleri")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Konum De�i�kenleri")]
    public Transform ownTransform;

    //[Header("Component De�i�kenleri")]
    //public Animator animator;

    [Header("Alg�lama De�i�kenleri")]
    public float attackRadius;

    [Header("Sald�r� De�i�kenleri")]
    public float attackTime;
}
