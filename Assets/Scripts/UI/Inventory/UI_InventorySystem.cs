using UnityEngine;

// UI �󿡼� �̷������ �κ��丮 �ý��� Ŭ����.
public class UI_InventorySystem : MonoBehaviour
{
    private static UI_InventorySystem s_instance = null;
    public static UI_InventorySystem GetInstance { get { return s_instance; } }

    private UI_InventorySlot[] _slots = null;

    private void Awake()
    {
        s_instance = this;

        _slots = transform.GetComponentsInChildren<UI_InventorySlot>();
    }

    public bool TryAddItem(Item item)
    {
        foreach (var slot in _slots)
        {
            if (slot.transform.childCount == 0)
            {
                item.transform.SetParent(slot.transform);
                item.transform.position = slot.transform.position;
                Destroy(item.GetComponent<CraftingInputItem>());
                Destroy(item.GetComponent<CraftingOutputItem>());
                return true;
            }
        }

        return false;
    }
}
