using UnityEngine;
using UnityEngine.EventSystems;

public class UI_InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        if (transform.childCount > 0)
        {
            return;
        }

        var go = eventData.pointerDrag;
        go.transform.SetParent(transform);
        go.transform.position = transform.position;

        var inputItem = go.GetComponent<CraftingInputItem>();
        if (inputItem != null)
        {
            UI_CraftingSystem.GetInstance.SetItem(ItemList.Items.None, inputItem.X, inputItem.Y);
            Destroy(inputItem);
        }

        var outputItem = go.GetComponent<CraftingOutputItem>();
        if (outputItem != null)
        {
            UI_CraftingSystem.GetInstance.DestroyAllItem();
            Destroy(outputItem);
        }
    }
}
