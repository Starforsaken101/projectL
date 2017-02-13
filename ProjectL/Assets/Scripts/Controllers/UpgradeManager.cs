using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Upgrade
{
    [StringValue("Tiny Magnet")]
    TINY_MAGNET,
    [StringValue("Float Time")]
    FLOAT_TIME,
    [StringValue("Catchup Speed")]
    CATCHUP_SPEED
}

public class UpgradeManager
{
    public struct TinyMagnet
    {
        public float radius;
        public int cost;
        public TutorialState flavorText;
        public TinyMagnet (float radius, int cost)
        {
            this.radius = radius;
            this.cost = cost;
            this.flavorText = TutorialState.SHOP_UPGRADE_TINY_MAGNET;
        }
    }

    public struct FloatTime
    {
        public float floatTime;
        public int cost;
        public TutorialState flavorText;
        public FloatTime(float floatTime, int cost)
        {
            this.floatTime = floatTime;
            this.cost = cost;
            this.flavorText = TutorialState.SHOP_UPGRADE_FLOAT_TIME;
        }
    }

    public struct CatchupSpeed
    {
        public float speed;
        public int cost;
        public TutorialState flavorText;
        public CatchupSpeed(float speed, int cost)
        {
            this.speed = speed;
            this.cost = cost;
            this.flavorText = TutorialState.SHOP_UPGRADE_CATCHUP_SPEED;
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
        _currentCatchupSpeed = _catchupSpeedUpgradePath[SaveFileManager.Instance.CatchupSpeedUpgradeLevel];
    }

    public TutorialState GetFlavorText(Upgrade upgrade)
    {
        switch(upgrade)
        {
            case Upgrade.TINY_MAGNET:
                return _currentTinyMagnet.flavorText;
            case Upgrade.FLOAT_TIME:
                return _currentFloatTime.flavorText;
            case Upgrade.CATCHUP_SPEED:
                return _currentCatchupSpeed.flavorText;
        }
        Debug.LogError("[UpgradeManager:IsMaxUpgrade] Upgrade does not exist");
        return TutorialState.NONE;
    }

    public bool IsMaxUpgrade(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.TINY_MAGNET:
                return (GetUpgradeLevelOfTinyMagnet() == _tinyMagnetUpgradePath.Count - 1);
            case Upgrade.FLOAT_TIME:
                return (GetUpgradeLevelOfFloatTime() == _floatTimeUpgradePath.Count - 1);
            case Upgrade.CATCHUP_SPEED:
                return (GetUpgradeLevelOfCatchupSpeed() == _catchupSpeedUpgradePath.Count - 1);
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
            case Upgrade.CATCHUP_SPEED:
                return GetNextCatchupSpeedLevel().cost;
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
            case Upgrade.CATCHUP_SPEED:
                return GetUpgradeLevelOfCatchupSpeed();
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
            case Upgrade.CATCHUP_SPEED:
                UpgradeCatchupSpeed();
                break;
        }
    }

    /*------------------TINY MAGNET------------------*/
    private TinyMagnet _currentTinyMagnet;
    public TinyMagnet CurrentTinyMagnet {  get { return _currentTinyMagnet; } }

    private List<TinyMagnet> _tinyMagnetUpgradePath = new List<TinyMagnet> { new TinyMagnet(0.9f, 0), new TinyMagnet(1.0f, 10),
                                                                             new TinyMagnet(1.1f, 40), new TinyMagnet(1.2f, 80)};

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

    private List<FloatTime> _floatTimeUpgradePath = new List<FloatTime> { new FloatTime(0f, 0), new FloatTime(0.5f, 10),
                                                                          new FloatTime(1.0f, 40), new FloatTime(1.2f, 80)};

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

    /*------------------CATCHUP SPEED------------------*/
    private CatchupSpeed _currentCatchupSpeed;
    public CatchupSpeed CurrentCatchupSpeed { get { return _currentCatchupSpeed; } }

    private List<CatchupSpeed> _catchupSpeedUpgradePath = new List<CatchupSpeed> { new CatchupSpeed(0.5f, 0), new CatchupSpeed(0.75f, 10),
                                                                                   new CatchupSpeed(1.0f, 40), new CatchupSpeed(1.5f, 80)};

    private int GetUpgradeLevelOfCatchupSpeed() { return _catchupSpeedUpgradePath.IndexOf(_currentCatchupSpeed); }
    private CatchupSpeed GetNextCatchupSpeedLevel()
    {
        int upgradeLevel = GetUpgradeLevelOfCatchupSpeed();
        if (upgradeLevel < _catchupSpeedUpgradePath.Count - 1)
        {
            return _catchupSpeedUpgradePath[upgradeLevel + 1];
        }
        return _currentCatchupSpeed;
    }

    private void UpgradeCatchupSpeed()
    {
        _currentCatchupSpeed = GetNextCatchupSpeedLevel();
        SaveFileManager.Instance.CatchupSpeedUpgradeLevel = GetUpgradeLevelOfCatchupSpeed();
    }
}
