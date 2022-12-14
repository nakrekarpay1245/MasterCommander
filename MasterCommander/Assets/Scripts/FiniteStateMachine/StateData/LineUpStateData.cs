using UnityEngine;

[CreateAssetMenu(fileName = "LineUp State Data",
    menuName = "Finite State Machine / State Data / LineUp State Data")]

public class LineUpStateData : ScriptableObject
{
    [Header("Hareket Değişkenleri")]
    public float moveSpeed;
    public float rotateSpeed;
}
