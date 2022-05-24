using UnityEngine;

public class UI_AddItemButton : MonoBehaviour
{
    private void Start()
    {
        makeAndAddItem(ItemList.Items.OakWood.ToString());
        makeAndAddItem(ItemList.Items.String.ToString());
        makeAndAddItem(ItemList.Items.Carrot.ToString());
        makeAndAddItem(ItemList.Items.IronIngot.ToString());
        makeAndAddItem(ItemList.Items.CobbleStone.ToString());
    }

    public void OnButtonAddWood()
    {
        makeAndAddItem("OakWood");
    }

    public void OnButtonAddString()
    {
        makeAndAddItem("String");
    }

    public void OnButtonAddCarrot()
    {
        makeAndAddItem("Carrot");
    }

    public void OnButtonAddIronIngot()
    {
        makeAndAddItem("IronIngot");
    }

    public void OnButtonAddStone()
    {
        makeAndAddItem("CobbleStone");
    }

    private void makeAndAddItem(string name)
    {
        var go = CraftingSystem.MakeAndGetItem(name);
        var item = go.GetComponent<Item>();
        if (!UI_InventorySystem.GetInstance.TryAddItem(item))
        {
            Destroy(item.gameObject);
        }
    }
}
