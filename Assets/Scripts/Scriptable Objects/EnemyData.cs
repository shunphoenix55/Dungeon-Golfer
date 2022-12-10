using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Enemy Data", fileName ="Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float maxHealth = 100f;
    public float attackDamage = 10f;
    public float mass = 1f;
}
