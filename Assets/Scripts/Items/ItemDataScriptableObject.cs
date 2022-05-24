using UnityEngine;

[System.Serializable]
public class SubArray
{
    public ItemList.Items[] cols;
}

[System.Serializable]
public class Recipe
{
    public SubArray[] rows;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemDataScriptableObject", order = 1)]
public class ItemDataScriptableObject : ScriptableObject
{
    public ItemList.Items ItemName;
    public Recipe Recipe;
}
