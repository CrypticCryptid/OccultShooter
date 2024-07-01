using UnityEngine;

public class InventoryPedestal : MonoBehaviour
{
    public Transform modelPos;
    bool hasItem = false;
    GameObject pedestalModel;
    
    Item item;

    // void Start() {
    //     model.SetActive(false);
    // }

    public void AddItem(Item newItem) {
        item = newItem;

        pedestalModel = Instantiate(item.model, modelPos.position, Quaternion.identity);
        pedestalModel.SetActive(true);         

        // if(!hasItem) {
        //     pedestalModel = Instantiate(item.model, modelPos.position, Quaternion.identity);
        //     hasItem = true;
        // } else {
        //     pedestalModel.SetActive(true);
        // }
        
    }

    public void ClearSlot() {
        item = null;

        pedestalModel = null;
        pedestalModel.SetActive(false);

        //pedestalModel.SetActive(false);
    }

    // public void UseItem() { //This function was used for when the item was clicked in the UI to activate it. Probably just used to equip in our game
    //     if(item != null) {
    //         item.Use();
    //     }
    // }
}
