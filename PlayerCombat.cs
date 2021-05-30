using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public HealthManager targetHealth;
    public PlayerStats playerStats;

    private float attackCooldown = 0f;

    void Start()
    {
        playerStats = PlayerStats.instance;
    }


    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(int damage)
    {
        if (attackCooldown <= 0f)
        {
            damage = playerStats.currentAttack;
            Debug.Log("Attack deals " + damage + " damage to " + targetHealth.gameObject.name);
            attackCooldown = 1f / attackSpeed;
            targetHealth.TakeDamage(damage);
        }
    }
}
