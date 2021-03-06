﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityIntEvent : UnityEvent<int> { }

[System.Serializable]
public class UnityStringEvent : UnityEvent<String> { }

[System.Serializable]
public class PopupEvent : UnityEvent<Popups> { }

[System.Serializable]
public class PowerupEvent : UnityEvent<Powerup> { }

[System.Serializable]
public class EquipClothingItemEvent : UnityEvent<ClothingType, string> { }

public static class Utils
{
    public const string ROOT_CLOTHING_PATH = "Sprites/Clothing/";
    public const string ROOT_UPGRADE_PATH = "Sprites/Upgrades/";

    public const string SFX_ENEMY_DIE = "Sounds/340794__kuchenanderung1__slime-squish";
    public const string SFX_COLLECT_TEACUP = "Sounds/171583__fins__3-up-fast-1";
    public const string SFX_PLAYER_DEATH_BY_ENEMY = "Sounds/77525__superex1110__door-bump-1";
    public const string SFX_PLAYER_DEATH_BY_FALL = "Sounds/221626__ansel__body-impact";

    public static GameObject InstantiateGameObjectByPath(string path)
    {
        UnityEngine.Object prefab = Resources.Load(path);

        if (prefab == null)
            return null;

        GameObject go = (GameObject)GameObject.Instantiate(prefab);
        go.name = prefab.name;
        return go;
    }

    public static Sprite GetSpriteFromResources(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    public static string GetClothingPath(string currentSet, string clothingType)
    {
        return ROOT_CLOTHING_PATH + currentSet + "/" + clothingType;
    }

    public static IEnumerable<T> GetValues<T>()
    {
        return (T[])Enum.GetValues(typeof(T));
    }

    public static ClothingSet GetClothingEnum(string stringValue)
    {
        ClothingSet[] enums = (ClothingSet[])GetValues<ClothingSet>();
        for (int i = 0; i < enums.Length; i++)
        {
            if (StringEnum.GetStringValue(enums[i]) == stringValue)
            {
                return enums[i];
            }
        }
        return ClothingSet.DEFAULT_SET;
    }

    public static string ConvertListToString(List<string> clothingSaves)
    {
        string result = "";
        for (int i = 0; i < clothingSaves.Count; i++)
        {
            result += clothingSaves[i];

            if (i < clothingSaves.Count - 1)
                result += ",";
        }
        return result;
    }

    public static List<string> ConvertStringToClothingSaves(string clothingString)
    {
        List<string> clothingStrings = new List<string>();

        string[] clothing = clothingString.Split(',');
        for (int i = 0; i < clothing.Length; i++)
        {
            clothingStrings.Add(clothing[i]);
        }

        return clothingStrings;
    }

    public static AudioSource CreateSFX(string path)
    {
        GameObject tempSound = new GameObject();
        tempSound.name = path;
        AudioSource sfx = tempSound.AddComponent<AudioSource>();
        sfx.clip = Resources.Load<AudioClip>(path);
        sfx.playOnAwake = false;

        return sfx;
    }
}
