using UnityEngine;
using UnityEngine.UI;

public class UIShopUpgrade : MonoBehaviour
{
    [SerializeField]
    private Upgrade _upgrade;
    public Upgrade Upgrade
    {
        set
        {
            _upgrade = value;
            UpdateUIElements();
        }
    }

    [SerializeField]
    private Text _upgradeName;
    [SerializeField]
    private Text _upgradeLevel;
    [SerializeField]
    private Button _btnUpgrade;
    [SerializeField]
    private Text _cost;

    void OnEnable()
    {
        UpdateUIElements();
    }

    public void PurchaseUpgrade()
    {
        if (Inventory.Instance.TotalCats() >= UpgradeManager.Instance.GetNextUpgradeCost(_upgrade))
        {
            UpgradeManager.Instance.UpgradeUpgrade(_upgrade);
            Inventory.Instance.SpendCats(UpgradeManager.Instance.GetNextUpgradeCost(_upgrade));
            UpdateUIElements();
        }
    }

    private void UpdateUIElements()
    {
        _upgradeName.text = StringEnum.GetStringValue(_upgrade);
        _upgradeLevel.text = "Level " + (UpgradeManager.Instance.GetUpgradeLevel(_upgrade) + 1);

        if (UpgradeManager.Instance.IsMaxUpgrade(_upgrade))
        {
            _btnUpgrade.enabled = false;
            _cost.text = "MAX";
            return;
        }
        _cost.text = UpgradeManager.Instance.GetNextUpgradeCost(_upgrade).ToString();
    }
}
