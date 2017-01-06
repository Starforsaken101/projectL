using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInstantiateClothing : MonoBehaviour
{
    private const string PREFAB_PATH = "Prefabs/UI/p_clothingComponent";

    [SerializeField]
    private ClothingType _clothingType;

    void Awake()
    {
        List<ClothingItem> clothingItems = ClothingManager.Instance.GetClothingItemsByType(_clothingType);

        for (int i = 0; i < clothingItems.Count; i++)
        {
            GameObject clothingObject = Utils.InstantiateGameObjectByPath(PREFAB_PATH);
            UIClothingItem uiClothingItem = clothingObject.GetComponent<UIClothingItem>();
            uiClothingItem.ClothingType = _clothingType;
            uiClothingItem.ClothingItem = clothingItems[i];
            uiClothingItem.Initialize();

            clothingObject.transform.SetParent(gameObject.transform, false);
        }
    }
}
