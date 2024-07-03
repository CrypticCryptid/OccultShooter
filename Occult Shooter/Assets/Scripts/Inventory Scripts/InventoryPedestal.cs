using UnityEngine;

public class InventoryPedestal : MonoBehaviour
{
    public Transform modelPos;
    private GameObject pedestalModel;
    public Item item; // Make item public to be accessible from InventoryEquip

    public void AddItem(Item newItem)
    {
        item = newItem;

        if (pedestalModel != null)
        {
            Destroy(pedestalModel);
        }

        pedestalModel = Instantiate(item.model, modelPos.position, Quaternion.identity);
        pedestalModel.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;

        if (pedestalModel != null)
        {
            Destroy(pedestalModel);
        }
    }
}
