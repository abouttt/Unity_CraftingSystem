using UnityEngine;
using UnityEngine.EventSystems;

public class UI_CraftingSlot : MonoBehaviour, IDropHandler
{
    private int _x;
    private int _y;

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
        if (inputItem == null)
        {
            inputItem = go.AddComponent<CraftingInputItem>();
        }
        else
        {
            UI_CraftingSystem.GetInstance.SetItem(ItemList.Items.None, inputItem.X, inputItem.Y);
        }

        inputItem.X = _x;
        inputItem.Y = _y;

        UI_CraftingSystem.GetInstance.SetItem(go.GetComponent<Item>().ItemData.ItemName, _x, _y);
    }

    // ΩΩ∑‘¿« ¿Œµ¶Ω∫∏¶ º≥¡§.
    public void SetXY(int x, int y)
    {
        _x = x;
        _y = y;
    }
}
