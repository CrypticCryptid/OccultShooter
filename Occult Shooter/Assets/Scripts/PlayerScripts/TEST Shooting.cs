using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTShooting : MonoBehaviour
{
    public Camera cam;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) { //Checks if left mouse button is pressed
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Casts and records a ray from camera
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) { //Checks if ray hits an object
                hit.collider.GetComponent<ITakeDamage>().TakeDamage(damage);
            }
        }
    }
}
