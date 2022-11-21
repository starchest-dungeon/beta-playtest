using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isDead = false;
    public int maxHealth = 4;
    public int currentHealth;
    public int kills = 0;

    public HealthBar healthBar;

    public GameOverScreen GameOverScreen;
    
    public VictoryScreen VictoryScreen;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //ZeldaHealthBar.instance.SetUpHearts(maxHealth);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(1);
        }
        */
        if (currentHealth <= 0) 
        {
            GameOver();
            gameObject.SetActive(false);
        }

        if (kills == 15) {
            Victory();
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage) 
    {
        //Debug.Log("In taking damage");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //ZeldaHealthBar.instance.RemoveHearts(damage);
        //Debug.Log("Out of taking damage");
    }

    public void GameOver() 
    {
        GameOverScreen.SetUp();
    }

    public void Victory() {
        VictoryScreen.SetUp();
    }
}
