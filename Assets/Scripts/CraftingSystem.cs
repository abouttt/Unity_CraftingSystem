using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem
{
    public readonly int X_SIZE;
    public readonly int Y_SIZE;

    private ItemList.Items[,] _items = null;
    public ItemList.Items this[int x, int y]
    {
        get { return _items[x, y]; }
        set { _items[x, y] = value; }
    }

    private List<ItemDataScriptableObject> _itemDataList = null;

    public CraftingSystem(int xSize, int ySize)
    {
        X_SIZE = xSize;
        Y_SIZE = ySize;

        _items = new ItemList.Items[X_SIZE, Y_SIZE];

        loadItemData();
    }

    public static GameObject MakeAndGetItem(string name)
    {
        var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Item"));
        if (go == null)
        {
            return null;
        }

        var texture = Resources.Load<Texture2D>($"Textures/items/{name}");
        go.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        go.GetComponent<Item>().ItemData = Resources.Load<ItemDataScriptableObject>($"Data/{name}ItemData");
        return go;
    }

    public GameObject MatchingRecipesAndGetItem(int inX, int inY)
    {
        bool hasRecipe = false;
        ItemDataScriptableObject itemData = null;
        for (int i = 0; i < _itemDataList.Count; i++)
        {
            hasRecipe = true;
            itemData = _itemDataList[i];

            if (_items[inX, inY] != _itemDataList[i].Recipe.rows[inX].cols[inY])
            {
                continue;
            }

            for (int x = 0; x < X_SIZE; x++)
            {
                for (int y = 0; y < Y_SIZE; y++)
                {
                    if (_items[x, y] != _itemDataList[i].Recipe.rows[x].cols[y])
                    {
                        hasRecipe = false;
                        break;
                    }
                }

                if (!hasRecipe)
                {
                    break;
                }
            }

            if (hasRecipe)
            {
                return MakeAndGetItem(itemData.ItemName.ToString());
            }
        }

        return null;
    }

    private void loadItemData()
    {
        _itemDataList = new List<ItemDataScriptableObject>();
        var itemNames = Enum.GetNames(typeof(ItemList.Items));
        for (int i = 1; i < itemNames.Length; i++)
        {
            var temp = Resources.Load<ItemDataScriptableObject>($"Data/{itemNames[i]}ItemData");
            if (temp.Recipe.rows.Length > 0)
            {
                _itemDataList.Add(temp);
            }
        }
    }
}
