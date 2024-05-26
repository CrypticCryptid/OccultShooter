using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PlayerHealth : MonoBehaviour, ITakeDamage
{
    public int health;
    public int currHealth;

    public HealthBar hpBar;

    void Start() {
        currHealth = health;
        hpBar.SetMaxHealth(health);
    }

    void Update() {
        if(currHealth <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int value) {
        currHealth -= value;

        hpBar.SetHealth(currHealth);
    }
}
