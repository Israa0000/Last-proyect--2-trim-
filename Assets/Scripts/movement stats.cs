using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement Parameters", menuName = "Movement Stats")]
public class MovementStats : ScriptableObject
{
    public float acceleration;
    public float maxSpeed;
    public float friction;
}
