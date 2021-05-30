using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{ 
    public int currentLevel;
    public int currentExperience;
    public int[] toLevelUp;
    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHP;
    public int currentAttack;
    public int currentDefense;
    public float currentAttackRange;
    public float defaultAttackRange = 2f;
    public static PlayerStats instance;

    private HealthManager playerHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHP = hpLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
        currentAttackRange = defaultAttackRange;
        playerHealth = Player.instance.GetComponent<HealthManager>();
    }


    void Update()
    {
        if (currentExperience >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
        if (playerHealth.currentHealth <= 0)
        {
            Debug.Log("0 hp");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = hpLevels[currentLevel];
        currentAttack += attackLevels[currentLevel];
        currentDefense += defenseLevels[currentLevel];
        playerHealth.maxHealth = currentHP;
        playerHealth.currentHealth += currentHP - hpLevels[currentLevel - 1];
    }

    public void AddExperience(int earnedExperience)
    {
        currentExperience += earnedExperience;
    }
}
