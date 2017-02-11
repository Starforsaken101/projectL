using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ClothingSet
{
    [StringValue("None")]
    NONE,
    [StringValue("DefaultSet")]
    DEFAULT_SET,
    [StringValue("RedDressSet")]
    RED_DRESS_SET,
    [StringValue("PHSet")]
    PH_SET,
    [StringValue("RedHair")]
    RED_HAIR,
    [StringValue("GreenHair")]
    GREEN_HAIR,
    [StringValue("PurpleHair")]
    PURPLE_HAIR,
    [StringValue("PinkHair")]
    PINK_HAIR,
    [StringValue("BlueHair")]
    BLUE_HAIR,
    [StringValue("YellowHeadphones")]
    YELLOW_HEADPHONES,
    [StringValue("PinkHeadphones")]
    PINK_HEADPHONES,
    [StringValue("PurpleHeadphones")]
    PURPLE_HEADPHONES,
    [StringValue("GreenHeadphones")]
    GREEN_HEADPHONES,
    [StringValue("RedHeadphones")]
    RED_HEADPHONES,
    [StringValue("LightBlueHeadphones")]
    LIGHT_BLUE_HEADPHONES
}

public enum ClothingType
{
    [StringValue("hair")]
    HAIR,
    [StringValue("hairAccessory")]
    HAIR_ACCESSORY,
    [StringValue("top")]
    TOP,
    [StringValue("bottom")]
    BOTTOM,
    [StringValue("shoes")]
    SHOES
}

public struct ClothingItem
{
    public ClothingSet set;
    public int cost;

    public ClothingItem(ClothingSet set, int cost)
    {
        this.set = set;
        this.cost = cost;
    }
}

public class ClothingManager
{
    private static ClothingManager _instance;
    public static ClothingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ClothingManager();
            }
            return _instance;
        }
    }
    
    private ClothingManager()
    {
        Instantiate();
    }

    public EquipClothingItemEvent OnClothingItemUpdated = new EquipClothingItemEvent();
    public UnityEvent OnHairChanged = new UnityEvent();
    public UnityEvent OnHairAccessoryChanged = new UnityEvent();
    public UnityEvent OnTopChanged = new UnityEvent();
    public UnityEvent OnBottomChanged = new UnityEvent();
    public UnityEvent OnShoesChanged = new UnityEvent();

    private void Instantiate()
    {
        _currentHair = Utils.GetClothingEnum(SaveFileManager.Instance.ClothingHair);
        _currentHairAccessory = Utils.GetClothingEnum(SaveFileManager.Instance.ClothingHairAccessory);
        _currentTop = Utils.GetClothingEnum(SaveFileManager.Instance.ClothingTop);
        _currentBottom = Utils.GetClothingEnum(SaveFileManager.Instance.ClothingBottom);
        _currentShoes = Utils.GetClothingEnum(SaveFileManager.Instance.ClothingShoes);

        AddDefaultItemsToSaveFile();
    }

    private void AddDefaultItemsToSaveFile()
    {
        AddDefaultItemsToSaveFile(hairCollection, ClothingType.HAIR);
        AddDefaultItemsToSaveFile(hairAccessoryCollection, ClothingType.HAIR_ACCESSORY);
        AddDefaultItemsToSaveFile(topCollection, ClothingType.TOP);
        AddDefaultItemsToSaveFile(bottomCollection, ClothingType.BOTTOM);
        AddDefaultItemsToSaveFile(shoeCollection, ClothingType.SHOES);
    }

    private void AddDefaultItemsToSaveFile(List<ClothingItem> clothing, ClothingType clothingType)
    {
        for (int i = 0; i < clothing.Count; i++)
        {
            if (clothing[i].set == ClothingSet.DEFAULT_SET)
            {
                SaveFileManager.Instance.AddToOwned(clothingType, StringEnum.GetStringValue(clothing[i].set));
            }
        }
    }

    public List<ClothingItem> GetClothingItemsByType(ClothingType clothingType)
    {
        switch (clothingType)
        {
            case ClothingType.HAIR:
                return hairCollection;
            case ClothingType.HAIR_ACCESSORY:
                return hairAccessoryCollection;
            case ClothingType.TOP:
                return topCollection;
            case ClothingType.BOTTOM:
                return bottomCollection;
            case ClothingType.SHOES:
                return shoeCollection;
        }
        return hairCollection;
    }

    public bool IsClothingItemEquipped(ClothingType clothingType, ClothingItem clothingItem)
    {
        switch (clothingType)
        {
            case ClothingType.HAIR:
                return (_currentHair == clothingItem.set);
            case ClothingType.HAIR_ACCESSORY:
                return (_currentHairAccessory == clothingItem.set);
            case ClothingType.TOP:
                return (_currentTop == clothingItem.set);
            case ClothingType.BOTTOM:
                return (_currentBottom == clothingItem.set);
            case ClothingType.SHOES:
                return (_currentShoes == clothingItem.set);
        }
        return false;
    }

    public void PurchaseClothingItem(ClothingType clothingType, ClothingItem clothingItem)
    {
        SaveFileManager.Instance.AddToOwned(clothingType, StringEnum.GetStringValue(clothingItem.set));
        EquipClothingItem(clothingType, clothingItem);
    }

    public void EquipClothingItem(ClothingType clothingType, ClothingItem clothingItem)
    {
        switch (clothingType)
        {
            case ClothingType.HAIR:
                _currentHair = clothingItem.set;
                SaveFileManager.Instance.ClothingHair = StringEnum.GetStringValue(_currentHair);
                OnClothingItemUpdated.Invoke(clothingType, StringEnum.GetStringValue(_currentHair));
                OnHairChanged.Invoke();
                break;
            case ClothingType.HAIR_ACCESSORY:
                _currentHairAccessory = clothingItem.set;
                SaveFileManager.Instance.ClothingHairAccessory = StringEnum.GetStringValue(_currentHairAccessory);
                OnClothingItemUpdated.Invoke(clothingType, StringEnum.GetStringValue(_currentHairAccessory));
                OnHairAccessoryChanged.Invoke();
                break;
            case ClothingType.TOP:
                _currentTop = clothingItem.set;
                SaveFileManager.Instance.ClothingTop = StringEnum.GetStringValue(_currentTop);
                OnClothingItemUpdated.Invoke(clothingType, StringEnum.GetStringValue(_currentTop));
                OnTopChanged.Invoke();
                break;
            case ClothingType.BOTTOM:
                _currentBottom = clothingItem.set;
                SaveFileManager.Instance.ClothingBottom = StringEnum.GetStringValue(_currentBottom);
                OnClothingItemUpdated.Invoke(clothingType, StringEnum.GetStringValue(_currentBottom));
                OnBottomChanged.Invoke();
                break;
            case ClothingType.SHOES:
                _currentShoes = clothingItem.set;
                SaveFileManager.Instance.ClothingShoes = StringEnum.GetStringValue(_currentShoes);
                OnClothingItemUpdated.Invoke(clothingType, StringEnum.GetStringValue(_currentShoes));
                OnShoesChanged.Invoke();
                break;
        }
    }

    public bool IsClothingItemOwned(ClothingType clothingType, ClothingItem clothingItem)
    {
        return SaveFileManager.Instance.IsSetOwned(clothingType, StringEnum.GetStringValue(clothingItem.set));
    }

    private ClothingSet _currentHair;
    public ClothingSet CurrentHair {  get { return _currentHair; } }
    private List<ClothingItem> hairCollection = new List<ClothingItem> { new ClothingItem(ClothingSet.DEFAULT_SET, 0),
                                                                         new ClothingItem(ClothingSet.RED_HAIR, 0),
                                                                         new ClothingItem(ClothingSet.GREEN_HAIR, 0),
                                                                         new ClothingItem(ClothingSet.PURPLE_HAIR, 0),
                                                                         new ClothingItem(ClothingSet.PINK_HAIR, 0),
                                                                         new ClothingItem(ClothingSet.BLUE_HAIR, 0)};

    private ClothingSet _currentTop;
    public ClothingSet CurrentTop { get { return _currentTop; } }
    private List<ClothingItem> topCollection = new List<ClothingItem> { new ClothingItem(ClothingSet.DEFAULT_SET, 0),
                                                                        new ClothingItem(ClothingSet.RED_DRESS_SET, 0),
                                                                        new ClothingItem(ClothingSet.PH_SET, 0) };

    private ClothingSet _currentBottom;
    public ClothingSet CurrentBottom { get { return _currentBottom; } }
    private List<ClothingItem> bottomCollection = new List<ClothingItem> { new ClothingItem(ClothingSet.DEFAULT_SET, 0),
                                                                           new ClothingItem(ClothingSet.RED_DRESS_SET, 0),
                                                                           new ClothingItem(ClothingSet.PH_SET, 0) };

    private ClothingSet _currentHairAccessory;
    public ClothingSet CurrentHairAccessory { get { return _currentHairAccessory; } }
    private List<ClothingItem> hairAccessoryCollection = new List<ClothingItem> { new ClothingItem(ClothingSet.NONE, 0),
                                                                                  new ClothingItem(ClothingSet.DEFAULT_SET, 0),
                                                                                  new ClothingItem(ClothingSet.YELLOW_HEADPHONES, 0),
                                                                                  new ClothingItem(ClothingSet.PINK_HEADPHONES, 0),
                                                                                  new ClothingItem(ClothingSet.PURPLE_HEADPHONES, 0),
                                                                                  new ClothingItem(ClothingSet.GREEN_HEADPHONES, 0),
                                                                                  new ClothingItem(ClothingSet.RED_HEADPHONES, 0),
                                                                                  new ClothingItem(ClothingSet.LIGHT_BLUE_HEADPHONES, 0)};

    private ClothingSet _currentShoes;
    public ClothingSet CurrentShoes { get { return _currentShoes; } }
    private List<ClothingItem> shoeCollection = new List<ClothingItem> { new ClothingItem(ClothingSet.DEFAULT_SET, 0) };
}
