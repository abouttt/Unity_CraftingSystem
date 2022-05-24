using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{
    // ΩÃ±€≈Ê.
    private static UI_CraftingSystem s_instance = null;
    public static UI_CraftingSystem GetInstance { get { return s_instance; } }

    private CraftingSystem _craftingSystem = null;
    private UI_CraftingSlot[,] _slots = null;     
    private Transform _outputSlot = null;         

    private void Awake()
    {
        s_instance = this;

        _craftingSystem = new CraftingSystem(3, 3);

        _outputSlot = transform.Find("OutputSlot");

        _slots = new UI_CraftingSlot[_craftingSystem.X_SIZE, _craftingSystem.Y_SIZE];
        for (int x = 0; x < _craftingSystem.X_SIZE; x++)
        {
            for (int y = 0; y < _craftingSystem.Y_SIZE; y++)
            {
                _slots[x, y] = Util.FindChild<UI_CraftingSlot>(gameObject, $"slot_{x.ToString()}_{y.ToString()}", recursive: true);
                _slots[x, y].SetXY(x, y);
            }
        }
    }

    public void SetItem(ItemList.Items item, int x, int y)
    {
        _craftingSystem[x, y] = item;
        CheckRecipesAndSetOutputItem(x, y);
    }

    public void DestroyAllItem()
    {
        for (int x = 0; x < _craftingSystem.X_SIZE; x++)
        {
            for (int y = 0; y < _craftingSystem.Y_SIZE; y++)
            {
                if (_craftingSystem[x, y] != ItemList.Items.None)
                {
                    Destroy(_slots[x, y].transform.GetChild(0).gameObject);
                    _craftingSystem[x, y] = ItemList.Items.None;
                }
            }
        }
    }

    public void CheckRecipesAndSetOutputItem(int x, int y)
    {
        var go = _craftingSystem.MatchingRecipesAndGetItem(x, y);
        if (go != null)
        {
            go.transform.SetParent(_outputSlot);
            go.transform.position = _outputSlot.position;
            go.AddComponent<CraftingOutputItem>();
        }
        else
        {
            DestroyOutputItem();
        }
    }

    public void DestroyOutputItem()
    {
        if (_outputSlot.childCount != 0)
        {
            Destroy(_outputSlot.GetChild(0).gameObject);
        }
    }
}
