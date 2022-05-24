using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField]
    public ItemDataScriptableObject ItemData { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right)
        {
            return;
        }

        UI_CraftingSystem.GetInstance.DestroyOutputItem();
        Destroy(gameObject);
    }
}
