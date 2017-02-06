using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private TextMeshProUGUI _upgradeName;
    [SerializeField]
    private TextMeshProUGUI _upgradeLevel;
    [SerializeField]
    private Button _btnUpgrade;
    [SerializeField]
    private TextMeshProUGUI _cost;
    [SerializeField]
    private TextMeshProUGUI _flavorText;
    [SerializeField]
    private Image _upgradeSprite;

    void OnEnable()
    {
        Inventory.Instance.OnCatsUpdated.AddListener(OnCatsUpdated);
        UpdateUIElements();
    }

    public void PurchaseUpgrade()
    {
        if (Inventory.Instance.TotalCats() >= UpgradeManager.Instance.GetNextUpgradeCost(_upgrade))
        {
            Inventory.Instance.SpendCats(UpgradeManager.Instance.GetNextUpgradeCost(_upgrade));
            UpgradeManager.Instance.UpgradeUpgrade(_upgrade);
            UpdateUIElements();
        }
    }

    private void UpdateUIElements()
    {
        _upgradeName.text = StringEnum.GetStringValue(_upgrade);
        _upgradeLevel.text = "Level " + (UpgradeManager.Instance.GetUpgradeLevel(_upgrade) + 1);

        LoadSprite();

        if (UpgradeManager.Instance.IsMaxUpgrade(_upgrade))
        {
            _btnUpgrade.interactable = false;
            _cost.text = "MAX";
            return;
        }
        _flavorText.text = GameController.Instance.GetStringForTutorialState(UpgradeManager.Instance.GetFlavorText(_upgrade));
        _cost.text = UpgradeManager.Instance.GetNextUpgradeCost(_upgrade).ToString();

        if (UpgradeManager.Instance.GetNextUpgradeCost(_upgrade) > Inventory.Instance.TotalCats())
        {
            _btnUpgrade.interactable = false;
        }
        else
        {
            _btnUpgrade.interactable = true;
        }
    }

    private void OnCatsUpdated(int cats)
    {
        if (UpgradeManager.Instance.GetNextUpgradeCost(_upgrade) > cats)
        {
            _btnUpgrade.interactable = false;
        }
        else
        {
            _btnUpgrade.interactable = true;
        }
    }

    private void LoadSprite()
    {
        Sprite sprUpgrade = null;
        switch (_upgrade)
        {
            case Upgrade.TINY_MAGNET:
                sprUpgrade = Resources.Load<Sprite>(Utils.ROOT_UPGRADE_PATH + "magnet");
                break;
            case Upgrade.FLOAT_TIME:
                sprUpgrade = Resources.Load<Sprite>(Utils.ROOT_UPGRADE_PATH + "float");
                break;
            case Upgrade.CATCHUP_SPEED:
                sprUpgrade = Resources.Load<Sprite>(Utils.ROOT_UPGRADE_PATH + "catchup");
                break;
        }

        if (sprUpgrade != null)
        {
            _upgradeSprite.sprite = sprUpgrade;
        }
    }
}
