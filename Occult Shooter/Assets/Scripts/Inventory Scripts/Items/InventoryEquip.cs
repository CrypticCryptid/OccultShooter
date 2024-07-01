using UnityEngine;

public class InventoryEquip : Interactable
{
    public Item item;
    private InventoryPedestal pedestal;

    private void Start()
    {
        pedestal = GetComponentInParent<InventoryPedestal>();
    }

    public override void Interact()
    {
        base.Interact();
        EquipItem();
    }

    void EquipItem()
    {
        if (item is Equipment equipmentItem)
        {
            EquipmentManager.instance.Equip(equipmentItem);
            pedestal.ClearSlot(); // Clear the pedestal once the item is equipped
        }
    }
}