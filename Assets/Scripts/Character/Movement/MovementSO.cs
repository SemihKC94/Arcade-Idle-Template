using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AI Movement Data",menuName ="Arcade Idle/Movement Data")]
public class MovementSO : ScriptableObject
{
    [Header("Movement Configuration")]
    public float movementSpeed = 150f;
    public float gravity = 3f;
}
