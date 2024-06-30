using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region  Singleton
    
    public static EquipmentManager instance;

    void Awake() {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start() {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem) {
        int slotIndex = (int)newItem.equipSlot; //Gets the type (knife, gun, spell, etc.) of the new item being picked up

        Equipment oldItem = null;

        //Checks if something is already in the slot the new item is trying to fill
        //If there is, the item filling the slot (the old item) is put back into the inventory
        if(currentEquipment[slotIndex] != null) {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        //Equips new item to player (removes from inventory)
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip (int slotIndex) {
        if(currentEquipment[slotIndex] != null) {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if(onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll() {
        for(int i = 0; i < currentEquipment.Length; i++) {
            Unequip(i);
        }
    }

    //This method is unnecessary for our game (at least I think so)
    void Update() {
        if(Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }
}
