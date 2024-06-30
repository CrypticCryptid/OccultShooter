using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGear : Interactable
{
    public Equipment gear;

    public override void Interact() {
        base.Interact();

        Equip();
    }

    void Equip() {
        Debug.Log("Equiping up " + gear.name);
        //bool wasPickedUp = 
        EquipmentManager.instance.Equip(gear);
        
        //if(wasPickedUp)
            gameObject.SetActive(false);
            //Destroy(gameObject);
    }    
}
