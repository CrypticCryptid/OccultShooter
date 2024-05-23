using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TEST_EnemyController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) { //Checks if left mouse button is pressed
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Casts and records a ray from camera
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) { //Checks if ray hits an object
                agent.SetDestination(hit.point); //Object moves to destination
            }
        }
    }
}
