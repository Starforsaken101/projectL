using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfigureClothing : MonoBehaviour
{
    void Awake()
    {
        Transform child;
        Transform[] childrenComponents = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < childrenComponents.Length; i++)
        {
            child = childrenComponents[i];

            if (child.gameObject.name == "hair")
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

    private void ConfigureClothing(Transform child, ClothingSet currentClothing)
    {
        if (child.parent.name == StringEnum.GetStringValue(currentClothing))
        {
            child.gameObject.SetActive(true);
        }
    }
}
