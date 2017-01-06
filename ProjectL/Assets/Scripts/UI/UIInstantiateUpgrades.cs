using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInstantiateUpgrades : MonoBehaviour
{
    private const string PREFAB_PATH = "Prefabs/UI/p_shopUpgradeComponent";

    void Awake()
    {
        var upgrades = Utils.GetValues<Upgrade>();
        foreach(Upgrade upgrade in upgrades)
        {
            GameObject upgradeObject = Utils.InstantiateGameObjectByPath(PREFAB_PATH);
            UIShopUpgrade uiShopUpgrade = upgradeObject.GetComponent<UIShopUpgrade>();
            uiShopUpgrade.Upgrade = upgrade;

            upgradeObject.transform.SetParent(gameObject.transform, false);
        }
    }
}
