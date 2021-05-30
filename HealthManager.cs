using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth;
    public int currentHealth;
    public int experience;
    public int killReward;

    private PlayerStats playerStats;
    private WaveSpawner waveSpawner;
    private Muny muny;

    void Start()
    {
        currentHealth = maxHealth;
        playerStats = PlayerStats.instance;
        healthBar.SetMaxHealth(maxHealth);
        waveSpawner = WaveSpawner.instance;
        muny = Muny.instance;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("Enemy"))
            {
                playerStats.AddExperience(experience);
                waveSpawner.enemyCount--;
                muny.currentMuny += killReward;
            }

            if (gameObject.CompareTag("Player"))
            {
                //todo GameOver screen
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
