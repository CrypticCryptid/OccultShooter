/* *
* @file EnemyController.cs
* @author Alec Ege
* @brief A general enemy controller intended to use as the basis for all enemies
* @date 2024 - 05 - 24
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, ITakeDamage, IDealDamage
{
    //Stat variables
    public int health;
    public int waveCost;
    
    //Attack variables
    public int damage;
    public float attackRange;
    public Transform attackPos;
    public LayerMask whatIsTargets;
    
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    //Movement variables
    public NavMeshAgent agent;
    public GameObject target;

    //Call on Awake for prefabs
    void Awake() {
        timeBtwAttack = startTimeBtwAttack;
        //When using prefabs, this will find the player
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        agent.SetDestination(target.transform.position); //Object moves to Vector3 destination

        //Mange object's health
        if(health <= 0) {
            Destroy(gameObject);
        }

        //Object Attacks after cool down and within range
        if(timeBtwAttack <= 0) {
            //Then you can attack
            Collider[] targetsToDamage = Physics.OverlapSphere(attackPos.position, attackRange, whatIsTargets);
            //Check to make sure that the player is within range
            if(targetsToDamage.Length > 0) {
                for(int i = 0; i < targetsToDamage.Length; i++) {
                    targetsToDamage[i].GetComponent<ITakeDamage>().TakeDamage(DealDamage()); //Do the attack
                }
            
                timeBtwAttack = startTimeBtwAttack;
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    /**
    * Interface method to deal damage
    * @return int
    */
    public int DealDamage() {
        return damage;
    }

    /**
    * Interface method to take damage
    * @param value
    * @return void
    */
    public void TakeDamage(int value) {
        health -= value;
    }

    /**
    * Gets the cost of the enemy
    * @return int
    */
    public int GetWaveCost() {
        return waveCost;
    }

    //This helps visualize the attack zone
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
