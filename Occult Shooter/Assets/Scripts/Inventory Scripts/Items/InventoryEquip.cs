using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEquip : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        EquipItem();
    }

    void EquipItem()
    {
        if (item != null)
        {
            EquipmentManager.instance.Equip(item as Equipment);

            // Remove item from inventory
            Inventory.instance.Remove(item);

            // Optionally, destroy the pedestal GameObject or handle item removal visually
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("No item assigned to InventoryEquip.");
        }
    }
}
