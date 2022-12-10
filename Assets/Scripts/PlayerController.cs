using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // using PlayerData for potentially having different values of health, attack and mass for different levels
    public PlayerData playerData;

    private float maxHealth;
    private float attackMultiplier;
    private float mass;

    private float _health;
    public float health
    {
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

    private Rigidbody rb;


    private void Start()
    {
        maxHealth = playerData.maxHealth;
        attackMultiplier = playerData.attackMultiplier;
        mass = playerData.mass;

        health = maxHealth;

        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

            // Damage inflicted depends on velocity of the player
            float attackMagnitude = rb.velocity.magnitude * attackMultiplier;

            enemyController.OnDamage(attackMagnitude);
        }
    }

}
