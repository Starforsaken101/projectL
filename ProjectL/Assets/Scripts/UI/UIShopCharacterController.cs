using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopCharacterController : MonoBehaviour
{
    [SerializeField]
    private Image _imgHair;
    [SerializeField]
    private Image _imgHairAccessory;
    [SerializeField]
    private Image _imgTop;
    [SerializeField]
    private Image _imgBottom;
    [SerializeField]
    private Image _imgShoes;

    void Awake()
    {
        ClothingManager.Instance.OnHairChanged.AddListener(OnHairChanged);
        ClothingManager.Instance.OnHairAccessoryChanged.AddListener(OnHairAccessoryChanged);
        ClothingManager.Instance.OnTopChanged.AddListener(OnTopChanged);
        ClothingManager.Instance.OnBottomChanged.AddListener(OnBottomChanged);
        ClothingManager.Instance.OnShoesChanged.AddListener(OnShoesChanged);
    }

    private void UpdateClothingItem(Image img, string path)
    {
        Sprite sprite = Utils.GetSpriteFromResources(path);
        if (sprite != null)
        {
            img.sprite = sprite;
        }
    }

    private void OnHairChanged()
    {
        string path = Utils.GetClothingPath(StringEnum.GetStringValue(ClothingManager.Instance.CurrentHair), StringEnum.GetStringValue(ClothingType.HAIR));
        UpdateClothingItem(_imgHair, path);
    }

    private void OnHairAccessoryChanged()
    {
        if (ClothingManager.Instance.CurrentHairAccessory == ClothingSet.NONE)
        {
            _imgHairAccessory.gameObject.SetActive(false);
        }
        else
        {
            _imgHairAccessory.gameObject.SetActive(true);
            string path = Utils.GetClothingPath(StringEnum.GetStringValue(ClothingManager.Instance.CurrentHairAccessory), StringEnum.GetStringValue(ClothingType.HAIR_ACCESSORY));
            UpdateClothingItem(_imgHairAccessory, path);
        }
    }

    private void OnTopChanged()
    {
        string path = Utils.GetClothingPath(StringEnum.GetStringValue(ClothingManager.Instance.CurrentTop), StringEnum.GetStringValue(ClothingType.TOP));
        UpdateClothingItem(_imgTop, path);
    }

    private void OnBottomChanged()
    {
        string path = Utils.GetClothingPath(StringEnum.GetStringValue(ClothingManager.Instance.CurrentBottom), StringEnum.GetStringValue(ClothingType.BOTTOM));
        UpdateClothingItem(_imgBottom, path);
    }

    private void OnShoesChanged()
    {
        string path = Utils.GetClothingPath(StringEnum.GetStringValue(ClothingManager.Instance.CurrentShoes), StringEnum.GetStringValue(ClothingType.SHOES));
        UpdateClothingItem(_imgShoes, path);
    }
}
