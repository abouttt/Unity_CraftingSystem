using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingInputItem : MonoBehaviour, IPointerClickHandler
{
    public int X { get; set; }
    public int Y { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        UI_CraftingSystem.GetInstance.SetItem(ItemList.Items.None, X, Y);
        if (!UI_InventorySystem.GetInstance.TryAddItem(GetComponent<Item>()))
        {
            Destroy(gameObject);
        }
    }
}
