using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData;

    public Slider healthSlider;

    private float maxHealth;
    private float attackDamage;
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
                healthSlider.value = _health / maxHealth;
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

        if (health <= 0f)
        {
            OnDeath();
        }
    }

    public void OnDeath(
)
    {
        Debug.Log(name + " destroyed");
        Destroy(gameObject);
    }

}
