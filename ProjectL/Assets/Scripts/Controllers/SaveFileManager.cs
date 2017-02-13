using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileManager
{
    private static SaveFileManager _instance;
    public static SaveFileManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveFileManager();
            }
            return _instance;
        }
    }

    private SaveFileManager()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        if (PlayerPrefs.HasKey(KEY_TINY_MAGNET_UPGRADE_LEVEL))
        {
            _tinyMagnetUpgradeLevel = PlayerPrefs.GetInt(KEY_TINY_MAGNET_UPGRADE_LEVEL);
        }
        else
        {
            PlayerPrefs.SetInt(KEY_TINY_MAGNET_UPGRADE_LEVEL, _tinyMagnetUpgradeLevel);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_FLOAT_TIME_UPGRADE_LEVEL))
        {
            _floatTimeUpgradeLevel = PlayerPrefs.GetInt(KEY_FLOAT_TIME_UPGRADE_LEVEL);
        }
        else
        {
            PlayerPrefs.SetInt(KEY_FLOAT_TIME_UPGRADE_LEVEL, _floatTimeUpgradeLevel);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_CATCHUP_SPEED_LEVEL))
        {
            _catchupSpeedUpgradeLevel = PlayerPrefs.GetInt(KEY_CATCHUP_SPEED_LEVEL);
        }
        else
        {
            PlayerPrefs.SetInt(KEY_CATCHUP_SPEED_LEVEL, _catchupSpeedUpgradeLevel);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_NUM_CATS))
        {
            _numCats = PlayerPrefs.GetInt(KEY_NUM_CATS);
        }
        else
        {
            PlayerPrefs.SetInt(KEY_NUM_CATS, _numCats);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_CLOTHING_HAIR))
        {
            _clothingHair = PlayerPrefs.GetString(KEY_CLOTHING_HAIR);
        }
        else
        {
            PlayerPrefs.SetString(KEY_CLOTHING_HAIR, _clothingHair);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_CLOTHING_HAIR_ACCESSORY))
        {
            _clothingHairAccessory = PlayerPrefs.GetString(KEY_CLOTHING_HAIR_ACCESSORY);
        }
        else
        {
            PlayerPrefs.SetString(KEY_CLOTHING_HAIR_ACCESSORY, _clothingHairAccessory);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_CLOTHING_TOP))
        {
            _clothingTop = PlayerPrefs.GetString(KEY_CLOTHING_TOP);
        }
        else
        {
            PlayerPrefs.SetString(KEY_CLOTHING_TOP, _clothingTop);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_CLOTHING_BOTTOM))
        {
            _clothingBottom = PlayerPrefs.GetString(KEY_CLOTHING_BOTTOM);
        }
        else
        {
            PlayerPrefs.SetString(KEY_CLOTHING_BOTTOM, _clothingBottom);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_CLOTHING_SHOES))
        {
            _clothingShoes = PlayerPrefs.GetString(KEY_CLOTHING_SHOES);
        }
        else
        {
            PlayerPrefs.SetString(KEY_CLOTHING_SHOES, _clothingShoes);
            PlayerPrefs.Save();
        }

        // OWNED CLOTHING
        if (PlayerPrefs.HasKey(KEY_OWNED_HAIR))
        {
            _ownedHair = Utils.ConvertStringToClothingSaves(PlayerPrefs.GetString(KEY_OWNED_HAIR));
        }
        if (PlayerPrefs.HasKey(KEY_OWNED_HAIR_ACCESSORY))
        {
            _ownedHairAccessory = Utils.ConvertStringToClothingSaves(PlayerPrefs.GetString(KEY_OWNED_HAIR_ACCESSORY));
        }
        if (PlayerPrefs.HasKey(KEY_OWNED_TOP))
        {
            _ownedTop = Utils.ConvertStringToClothingSaves(PlayerPrefs.GetString(KEY_OWNED_TOP));
        }
        if (PlayerPrefs.HasKey(KEY_OWNED_BOTTOM))
        {
            _ownedBottom = Utils.ConvertStringToClothingSaves(PlayerPrefs.GetString(KEY_OWNED_BOTTOM));
        }
        if (PlayerPrefs.HasKey(KEY_OWNED_SHOES))
        {
            _ownedShoes = Utils.ConvertStringToClothingSaves(PlayerPrefs.GetString(KEY_OWNED_SHOES));
        }

        // TUTORIALS
        if (PlayerPrefs.HasKey(KEY_TUTORIAL_COMPLETED))
        {
            _completedTutorial = PlayerPrefs.GetInt(KEY_TUTORIAL_COMPLETED) == 0 ? true : false;
        }
        else
        {
            PlayerPrefs.SetInt(KEY_TUTORIAL_COMPLETED, 1);
            PlayerPrefs.Save();
        }

        // SETTINGS
        if (PlayerPrefs.HasKey(KEY_SETTINGS_SOUND_ON))
        {
            _soundOn = PlayerPrefs.GetInt(KEY_SETTINGS_SOUND_ON) == 0 ? true : false;
        }
        else
        {
            PlayerPrefs.SetInt(KEY_SETTINGS_SOUND_ON, 0);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(KEY_SETTINGS_MUSIC_ON))
        {
            _musicOn = PlayerPrefs.GetInt(KEY_SETTINGS_MUSIC_ON) == 0 ? true : false;
        }
        else
        {
            PlayerPrefs.SetInt(KEY_SETTINGS_MUSIC_ON, 0);
            PlayerPrefs.Save();
        }
    }

    private const string KEY_TINY_MAGNET_UPGRADE_LEVEL = "TinyMagnetUpgradeLevel";
    private const string KEY_FLOAT_TIME_UPGRADE_LEVEL = "FloatTimeUpgradeLevel";
    private const string KEY_CATCHUP_SPEED_LEVEL = "CatchupSpeedUpgradeLevel";

    private const string KEY_NUM_CATS = "NumCats";

    private const string KEY_CLOTHING_HAIR = "ClothingHair";
    private const string KEY_CLOTHING_HAIR_ACCESSORY = "ClothingHairAccessory";
    private const string KEY_CLOTHING_TOP = "ClothingTop";
    private const string KEY_CLOTHING_BOTTOM = "ClothingBottom";
    private const string KEY_CLOTHING_SHOES = "ClothingShoes";

    private const string KEY_OWNED_HAIR = "OwnedHair";
    private const string KEY_OWNED_HAIR_ACCESSORY = "OwnedHairAccessory";
    private const string KEY_OWNED_TOP = "OwnedTop";
    private const string KEY_OWNED_BOTTOM = "OwnedBottom";
    private const string KEY_OWNED_SHOES = "OwnedShoes";

    private const string KEY_SETTINGS_SOUND_ON = "Sound";
    private const string KEY_SETTINGS_MUSIC_ON = "Music";

    private const string KEY_TUTORIAL_COMPLETED = "CompletedTutorial";

    private bool _completedTutorial = false;
    public bool CompletedTutorial
    {  
        get { return _completedTutorial; }
    }

    public void CompleteTutorial()
    {
        _completedTutorial = true;
        PlayerPrefs.SetInt(KEY_TUTORIAL_COMPLETED, 0);
        PlayerPrefs.Save();
    }

    private List<string> _ownedHair = new List<string>();
    private List<string> _ownedHairAccessory = new List<string>();
    private List<string> _ownedTop = new List<string>();
    private List<string> _ownedBottom = new List<string>();
    private List<string> _ownedShoes = new List<string>();

    public bool IsSetOwned(ClothingType clothingType, string set)
    {
        switch (clothingType)
        {
            case ClothingType.HAIR:
                return _ownedHair.Contains(set);
            case ClothingType.HAIR_ACCESSORY:
                return _ownedHairAccessory.Contains(set);
            case ClothingType.TOP:
                return _ownedTop.Contains(set);
            case ClothingType.BOTTOM:
                return _ownedBottom.Contains(set);
            case ClothingType.SHOES:
                return _ownedShoes.Contains(set);
        }
        return false;
    }

    public void AddToOwned(ClothingType clothingType, string set)
    {
        switch (clothingType)
        {
            case ClothingType.HAIR:
                if (!_ownedHair.Contains(set))
                {
                    _ownedHair.Add(set);
                    PlayerPrefs.SetString(KEY_OWNED_HAIR, Utils.ConvertListToString(_ownedHair));
                    PlayerPrefs.Save();
                }
                break;
            case ClothingType.HAIR_ACCESSORY:
                if (!_ownedHairAccessory.Contains(set))
                {
                    _ownedHairAccessory.Add(set);
                    PlayerPrefs.SetString(KEY_OWNED_HAIR_ACCESSORY, Utils.ConvertListToString(_ownedHairAccessory));
                    PlayerPrefs.Save();
                }
                break;
            case ClothingType.TOP:
                if (!_ownedTop.Contains(set))
                {
                    _ownedTop.Add(set);
                    PlayerPrefs.SetString(KEY_OWNED_TOP, Utils.ConvertListToString(_ownedTop));
                    PlayerPrefs.Save();
                }
                break;
            case ClothingType.BOTTOM:
                if (!_ownedBottom.Contains(set))
                {
                    _ownedBottom.Add(set);
                    PlayerPrefs.SetString(KEY_OWNED_BOTTOM, Utils.ConvertListToString(_ownedBottom));
                    PlayerPrefs.Save();
                }
                break;
            case ClothingType.SHOES:
                if (!_ownedShoes.Contains(set))
                {
                    _ownedShoes.Add(set);
                    PlayerPrefs.SetString(KEY_OWNED_SHOES, Utils.ConvertListToString(_ownedShoes));
                    PlayerPrefs.Save();
                }
                break;
        }
    }

    private string _clothingHair = StringEnum.GetStringValue(ClothingSet.DEFAULT_SET);
    public string ClothingHair
    {
        get { return _clothingHair; }
        set
        {
            _clothingHair = value;
            PlayerPrefs.SetString(KEY_CLOTHING_HAIR, _clothingHair);
            PlayerPrefs.Save();
        }
    }

    private string _clothingHairAccessory = StringEnum.GetStringValue(ClothingSet.DEFAULT_SET);
    public string ClothingHairAccessory
    {
        get { return _clothingHairAccessory; }
        set
        {
            _clothingHairAccessory = value;
            PlayerPrefs.SetString(KEY_CLOTHING_HAIR_ACCESSORY, _clothingHairAccessory);
            PlayerPrefs.Save();
        }
    }

    private string _clothingTop = StringEnum.GetStringValue(ClothingSet.DEFAULT_SET);
    public string ClothingTop
    {
        get { return _clothingTop; }
        set
        {
            _clothingTop = value;
            PlayerPrefs.SetString(KEY_CLOTHING_TOP, _clothingTop);
            PlayerPrefs.Save();
        }
    }

    private string _clothingBottom = StringEnum.GetStringValue(ClothingSet.DEFAULT_SET);
    public string ClothingBottom
    {
        get { return _clothingBottom; }
        set
        {
            _clothingBottom = value;
            PlayerPrefs.SetString(KEY_CLOTHING_BOTTOM, _clothingBottom);
            PlayerPrefs.Save();
        }
    }

    private string _clothingShoes = StringEnum.GetStringValue(ClothingSet.DEFAULT_SET);
    public string ClothingShoes
    {
        get { return _clothingShoes; }
        set
        {
            _clothingShoes = value;
            PlayerPrefs.SetString(KEY_CLOTHING_SHOES, _clothingShoes);
            PlayerPrefs.Save();
        }
    }

    private int _tinyMagnetUpgradeLevel;
    public int TinyMagnetUpgradeLevel
    {
        get { return _tinyMagnetUpgradeLevel; }
        set
        {
            _tinyMagnetUpgradeLevel = value;
            PlayerPrefs.SetInt(KEY_TINY_MAGNET_UPGRADE_LEVEL, _tinyMagnetUpgradeLevel);
            PlayerPrefs.Save();
        }
    }

    private int _catchupSpeedUpgradeLevel;
    public int CatchupSpeedUpgradeLevel
    {
        get { return _catchupSpeedUpgradeLevel; }
        set
        {
            _catchupSpeedUpgradeLevel = value;
            PlayerPrefs.SetInt(KEY_CATCHUP_SPEED_LEVEL, _catchupSpeedUpgradeLevel);
            PlayerPrefs.Save();
        }
    }

    private int _floatTimeUpgradeLevel;
    public int FloatTimeUpgradeLevel
    {
        get { return _floatTimeUpgradeLevel; }
        set
        {
            _floatTimeUpgradeLevel = value;
            PlayerPrefs.SetInt(KEY_FLOAT_TIME_UPGRADE_LEVEL, _floatTimeUpgradeLevel);
            PlayerPrefs.Save();
        }
    }

    private int _numCats = 0;
    public int NumCats
    {
        get { return _numCats; }
        set
        {
            _numCats = value;
            PlayerPrefs.SetInt(KEY_NUM_CATS, _numCats);
            PlayerPrefs.Save();
        }
    }

    private bool _soundOn = true;
    public bool Sound
    {
        get { return _soundOn; }
        set
        {
            _soundOn = value;
            PlayerPrefs.SetInt(KEY_SETTINGS_SOUND_ON, _soundOn ? 0 : 1);
            PlayerPrefs.Save();
        }
    }

    private bool _musicOn = true;
    public bool Music
    {
        get { return _musicOn; }
        set
        {
            _musicOn = value;
            PlayerPrefs.SetInt(KEY_SETTINGS_MUSIC_ON, _musicOn ? 0 : 1);
            PlayerPrefs.Save();

            if (_musicOn)
                AudioListener.volume = 1.0f;
            else
                AudioListener.volume = 0.0f;
        }
    }
}
