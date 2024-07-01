using UnityEngine;

public class ShopPickUp : Interactable
{
    public Item item;

    public override void Interact() {
        base.Interact();

        //If player has enough money then...
        BuyItem();
    }

    void BuyItem() {
        Debug.Log("Buying " + item.name);
        bool wasBought = Inventory.instance.Add(item);

        if(wasBought) {
            RemoveFromShop();
        }
    }

    void RemoveFromShop() {
        //Logic to remvoe the tiem from the shop's inventory
        Destroy(gameObject); //Assuming this removes the shop item from the scene
    }
}
