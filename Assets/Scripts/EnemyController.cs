using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData;

    private float maxHealth;
    private float attackDamage;
    private float mass;

    private float _health;
    public float health {
        get
        {
            return _health;
        }

        set
        {
            if (value > maxHealth)
            {
                _health = maxHealth;
            }
            else
            {
                _health = value;
            }
        }
            }


    void Start()
    {
        maxHealth = enemyData.maxHealth;
        attackDamage = enemyData.attackDamage;
        mass = enemyData.mass;

        health = maxHealth;
    }


    public void OnDamage(float damage)
    {
        health -= damage;
        Debug.Log(name + "has taken " + damage);
    }
}
