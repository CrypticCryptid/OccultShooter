/* *
* @file TEST_PlayerController.cs
* @author Alec Ege
* @brief A temporary stand in for player movement. The object teleports to predetermined transforms in an array
* @date 2024 - 05 - 24
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PlayerController : MonoBehaviour, ITakeDamage
{
    public Vector3[] positions;
    public int posNum;

    public int health;

    void Update()
    {
        //Simulate player movement
        gameObject.transform.position = positions[posNum];

        //Simulate player health
        if(health <= 0) {
            gameObject.SetActive(false);
        }
    }

    /**
    * Interface method to take damage
    * @param value
    * @return void
    */
    public void TakeDamage(int value) {
        health -= value;
    }
}
