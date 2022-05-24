using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingOutputItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        UI_CraftingSystem.GetInstance.DestroyAllItem();
        if (!UI_InventorySystem.GetInstance.TryAddItem(GetComponent<Item>()))
        {
            Destroy(gameObject);
        }
    }
}
