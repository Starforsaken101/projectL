using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfigureClothing : MonoBehaviour
{
    void Awake()
    {
        UpdateClothing();

        ClothingManager.Instance.OnBottomChanged.AddListener(UpdateClothing);
        ClothingManager.Instance.OnTopChanged.AddListener(UpdateClothing);
        ClothingManager.Instance.OnHairAccessoryChanged.AddListener(UpdateClothing);
        ClothingManager.Instance.OnHairChanged.AddListener(UpdateClothing);
        ClothingManager.Instance.OnShoesChanged.AddListener(UpdateClothing);
    }

    private void UpdateClothing()
    {
        DeactivateAllClothing();
        
        Transform child;
        Transform[] childrenComponents = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < childrenComponents.Length; i++)
        {
            child = childrenComponents[i];

            if (child.gameObject.name == "hair" && ClothingManager.Instance.CurrentTop != ClothingSet.MALEFICENT)
            {
                ConfigureClothing(child, ClothingManager.Instance.CurrentHair);
            }
            if (child.gameObject.name == "hairAccessory")
            {
                ConfigureClothing(child, ClothingManager.Instance.CurrentHairAccessory);
            }
            if (child.gameObject.name == "top")
            {
                ConfigureClothing(child, ClothingManager.Instance.CurrentTop);
            }
            if (child.gameObject.name == "bottom")
            {
                ConfigureClothing(child, ClothingManager.Instance.CurrentBottom);
            }
            if (child.gameObject.name == "shoes")
            {
                ConfigureClothing(child, ClothingManager.Instance.CurrentShoes);
            }
        }
    }

    private void DeactivateAllClothing()
    {
        Transform child;
        Transform[] childrenComponents = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < childrenComponents.Length; i++)
        {
            child = childrenComponents[i];

            if (child.gameObject.name == "hair" ||
                child.gameObject.name == "hairAccessory" ||
                child.gameObject.name == "top" ||
                child.gameObject.name == "bottom" ||
                child.gameObject.name == "shoes")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void ConfigureClothing(Transform child, ClothingSet currentClothing)
    {
        if (child.parent.name == StringEnum.GetStringValue(currentClothing))
        {
            child.gameObject.SetActive(true);
        }
    }
}
