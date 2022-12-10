using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Player Data", fileName ="Player Data")]
public class PlayerData : ScriptableObject
{
    public float maxHealth = 100f;
    public float attackMultiplier = 10f;
    public float mass = 1f;
}
