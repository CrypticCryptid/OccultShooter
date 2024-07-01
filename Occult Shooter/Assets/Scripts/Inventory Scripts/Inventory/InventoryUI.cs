using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    public Transform pedestalsParent;
    
    Inventory inventory;

    InventorySlot[] slots;
    InventoryPedestal[] pedestals;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        pedestals = pedestalsParent.GetComponentsInChildren<InventoryPedestal>();
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI() {
        // for(int i = 0; i < slots.Length; i++) {
        //     if(i < inventory.items.Count) {
        //         slots[i].AddItem(inventory.items[i]); //Make item appear on pedestal
        //     } else {
        //         slots[i].ClearSlot();
        //     }
        // }

        for(int i = 0; i < pedestals.Length; i++) {
            if(i < inventory.items.Count) {
                pedestals[i].AddItem(inventory.items[i]); //Make item appear on pedestal
            } else {
                pedestals[i].ClearSlot();
            }
        }        
    }   
}
