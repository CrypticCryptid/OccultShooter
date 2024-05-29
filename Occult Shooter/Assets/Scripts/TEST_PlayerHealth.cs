using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PlayerHealth : MonoBehaviour, ITakeDamage
{
    public int health;
    public int currHealth;

    public HealthBar hpBar;
    public PauseMenu UIMenu;

    void Start() {
        currHealth = health;
        hpBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        UIMenu = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseMenu>();
        hpBar.SetMaxHealth(health);
    }

    void Update() {
        if(currHealth <= 0) {
            //gameObject.SetActive(false);
            UIMenu.SetGameOver(true);
        }
    }

    public void TakeDamage(int value) {
        currHealth -= value;

        hpBar.SetHealth(currHealth);
    }
}
