/* *
* @file TEST_FollowPlayer.cs
* @author Alec Ege
* @brief Moves an one object to the destination of another tagged "Player" via NavMesh
* @date 2024 - 05 - 23
*/

//The turorial video said that these two namespaces were unnecessary
//I am keeping them just in case we need them later
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TEST_FollowPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    void Start() {
        //When using prefabs, this will find the player
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        agent.SetDestination(target.transform.position); //Object moves to Vector3 destination
    }
}
