using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIClothingItem : MonoBehaviour
{
    [SerializeField]
    private Button _btnBuy;
    [SerializeField]
    private Button _btnEquip;
    [SerializeField]
    private TextMeshProUGUI _txtCost;
    [SerializeField]
    private Image _imgEquipped;
    [SerializeField]
    private Image _imgClothingItem;

    private ClothingType _clothingType;
    public ClothingType ClothingType {  set { _clothingType = value; } }

    private ClothingItem _clothingItem;
    public ClothingItem ClothingItem {  set { _clothingItem = value; } }

    public void Initialize()
    {
        UpdateUIElements();
        ClothingManager.Instance.OnClothingItemUpdated.AddListener(OnClothingItemUpdated);
    }

    void OnDestroy()
    {
        ClothingManager.Instance.OnClothingItemUpdated.RemoveListener(OnClothingItemUpdated);
    }

    private void OnClothingItemUpdated(ClothingType clothingType, string set)
    {
        if (_clothingType == clothingType)
        {
            if (StringEnum.GetStringValue(_clothingItem.set) == set)
            {
                _imgEquipped.gameObject.SetActive(true);
            }
            else
            {
                _imgEquipped.gameObject.SetActive(false);
            }

            UpdateButtons();
        }
    }

    private void UpdateButtons()
    {
        if (ClothingManager.Instance.IsClothingItemOwned(_clothingType, _clothingItem) || _clothingItem.set == ClothingSet.NONE)
        {
            _btnBuy.gameObject.SetActive(false);
            _btnEquip.gameObject.SetActive(true);
        }
        else
        {
            _txtCost.text = _clothingItem.cost.ToString();
            _btnBuy.gameObject.SetActive(true);
            _btnEquip.gameObject.SetActive(false);
        }
    }

    private void UpdateUIElements()
    {
        UpdateButtons();

        if (ClothingManager.Instance.IsClothingItemEquipped(_clothingType, _clothingItem))
        {
            _imgEquipped.gameObject.SetActive(true);
            _btnEquip.gameObject.SetActive(false);
        }
        else
        {
            _imgEquipped.gameObject.SetActive(false);
        }

        Sprite sprClothing = Resources.Load<Sprite>(Utils.ROOT_CLOTHING_PATH + StringEnum.GetStringValue(_clothingItem.set) + "/" + StringEnum.GetStringValue(_clothingType));
        if (sprClothing != null)
        {
            _imgClothingItem.sprite = sprClothing;
        }
    }

    public void EquipClothingItem()
    {
        ClothingManager.Instance.EquipClothingItem(_clothingType, _clothingItem);
        UpdateUIElements();
    }

    public void BuyClothingItem()
    {
        if (Inventory.Instance.TotalCats() >= _clothingItem.cost)
        {
            Inventory.Instance.SpendCats(_clothingItem.cost);
            ClothingManager.Instance.PurchaseClothingItem(_clothingType, _clothingItem);
            UpdateUIElements();
        }
    }
}
