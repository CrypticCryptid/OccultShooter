using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_PlayerInteract : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if(Input.GetButtonDown("Interact")) { //Checks if left mouse button is pressed
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Casts and records a ray from camera
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) { //Checks if ray hits an object
                if(hit.collider.GetComponent<Interactable>().IsClose()) {
                    hit.collider.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
