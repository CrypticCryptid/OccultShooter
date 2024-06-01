using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_CameraLookInteraction : MonoBehaviour
{
    public Camera cam;
    Collider oldObject;
    Collider newObject;
    
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Casts and records a ray from camera
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) { //Checks if ray hits an object
            oldObject.GetComponent<Interactable>().OnDefocused();
            newObject = hit.collider;
            newObject.GetComponent<Interactable>().OnFocused(gameObject.transform);
            oldObject = newObject;
        } else {
            oldObject.GetComponent<Interactable>().OnDefocused();
        }
    }
}
