using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Upgrade
{
    [StringValue("Tiny Magnet")]
    TINY_MAGNET,
    [StringValue("Float Time")]
    FLOAT_TIME
}

public class UpgradeManager
{
    public struct TinyMagnet
    {
        public float radius;
        public int cost;
        public TinyMagnet (float radius, int cost)
        {
            this.radius = radius;
            this.cost = cost;
        }
    }

    public struct FloatTime
    {
        public float floatTime;
        public int cost;
        public FloatTime(float floatTime, int cost)
        {
            this.floatTime = floatTime;
            this.cost = cost;
        }
    }

    private static UpgradeManager _instance;
    public static UpgradeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UpgradeManager();
            }
            return _instance;
        }
    }

    private UpgradeManager()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        _currentTinyMagnet = _tinyMagnetUpgradePath[SaveFileManager.Instance.TinyMagnetUpgradeLevel];
        _currentFloatTime = _floatTimeUpgradePath[SaveFileManager.Instance.FloatTimeUpgradeLevel];
    }

    public bool IsMaxUpgrade(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.TINY_MAGNET:
                return (GetUpgradeLevelOfTinyMagnet() == _tinyMagnetUpgradePath.Count - 1);
            case Upgrade.FLOAT_TIME:
                return (GetUpgradeLevelOfFloatTime() == _floatTimeUpgradePath.Count - 1);
        }
        Debug.LogError("[UpgradeManager:IsMaxUpgrade] Upgrade does not exist");
        return false;
    }

    public int GetNextUpgradeCost(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.TINY_MAGNET:
                return GetNextTinyMagnetUpgrade().cost;
            case Upgrade.FLOAT_TIME:
                return GetNextFloatTimeUpgrade().cost;
        }
        Debug.LogError("[UpgradeManager:GetNextUpgradeCost] Upgrade does not exist");
        return 0;
    }

    public int GetUpgradeLevel(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.TINY_MAGNET:
                return GetUpgradeLevelOfTinyMagnet();
            case Upgrade.FLOAT_TIME:
                return GetUpgradeLevelOfFloatTime();
        }
        Debug.LogError("[UpgradeManager:GetUpgradeLevel] Upgrade does not exist");
        return 0;
    }

    public void UpgradeUpgrade(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.TINY_MAGNET:
                UpgradeTinyMagnet();
                break;
            case Upgrade.FLOAT_TIME:
                UpgradeFloatTime();
                break;
        }
    }

    /*------------------TINY MAGNET------------------*/
    private TinyMagnet _currentTinyMagnet;
    public TinyMagnet CurrentTinyMagnet {  get { return _currentTinyMagnet; } }

    private List<TinyMagnet> _tinyMagnetUpgradePath = new List<TinyMagnet> { new TinyMagnet(0.9f, 0), new TinyMagnet(1.0f, 2),
                                                                         new TinyMagnet(1.1f, 40), new TinyMagnet(1.2f, 60)};

    private int GetUpgradeLevelOfTinyMagnet() { return _tinyMagnetUpgradePath.IndexOf(_currentTinyMagnet); }
    private TinyMagnet GetNextTinyMagnetUpgrade()
    {
        int upgradeLevel = GetUpgradeLevelOfTinyMagnet();
        if (upgradeLevel < _tinyMagnetUpgradePath.Count - 1)
        {
            return _tinyMagnetUpgradePath[upgradeLevel + 1];
        }
        return _currentTinyMagnet;
    }

    private void UpgradeTinyMagnet()
    {
        _currentTinyMagnet = GetNextTinyMagnetUpgrade();
        SaveFileManager.Instance.TinyMagnetUpgradeLevel = GetUpgradeLevelOfTinyMagnet();
    }

    /*------------------FLOAT TIME------------------*/
    private FloatTime _currentFloatTime;
    public FloatTime CurrentFloatTime {  get { return _currentFloatTime; } }

    private List<FloatTime> _floatTimeUpgradePath = new List<FloatTime> { new FloatTime(0f, 0), new FloatTime(0.5f, 20),
                                                                          new FloatTime(1.0f, 40), new FloatTime(1.2f, 60)};

    private int GetUpgradeLevelOfFloatTime() { return _floatTimeUpgradePath.IndexOf(_currentFloatTime); }
    private FloatTime GetNextFloatTimeUpgrade()
    {
        int upgradeLevel = GetUpgradeLevelOfFloatTime();
        if (upgradeLevel < _floatTimeUpgradePath.Count - 1)
        {
            return _floatTimeUpgradePath[upgradeLevel + 1];
        }
        return _currentFloatTime;
    }

    private void UpgradeFloatTime()
    {
        _currentFloatTime = GetNextFloatTimeUpgrade();
        SaveFileManager.Instance.FloatTimeUpgradeLevel= GetUpgradeLevelOfFloatTime();
    }
}
