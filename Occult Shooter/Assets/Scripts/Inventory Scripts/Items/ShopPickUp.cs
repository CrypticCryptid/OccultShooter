using UnityEngine;

public class ShopPickUp : Interactable
{
    public Item item;

    public override void Interact() {
        base.Interact();

        //If player has enough money then...
        PickUp();
    }

    void PickUp() {
        Debug.Log("Buying " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }
}
