using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager
{
    public struct TinyMagnet
    {
        public float radius;
        public TinyMagnet (float radius)
        {
            this.radius = radius;
        }
    }

    public struct FloatTime
    {
        public float floatTime;
        public FloatTime(float floatTime)
        {
            this.floatTime = floatTime;
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
        Initialize();
    }

    /*------------------TINY MAGNET------------------*/
    private TinyMagnet _currentTinyMagnet;
    public TinyMagnet CurrentTinyMagnet {  get { return _currentTinyMagnet; } }

    private List<TinyMagnet> _tinyMagnetUpgradePath = new List<TinyMagnet> { new TinyMagnet(0.9f), new TinyMagnet(1.0f),
                                                                         new TinyMagnet(1.1f), new TinyMagnet(1.2f)};

    public int GetUpgradeLevelOfTinyMagnet() { return _tinyMagnetUpgradePath.IndexOf(_currentTinyMagnet); }

    /*------------------FLOAT TIME------------------*/
    private FloatTime _currentFloatTime;
    public FloatTime CurrentFloatTime {  get { return _currentFloatTime; } }

    private List<FloatTime> _floatTimeUpgradePath = new List<FloatTime> { new FloatTime(0f), new FloatTime(0.5f),
                                                                          new FloatTime(1.0f), new FloatTime(1.2f)};

    public int GetUpgradeLevelOfFloatTime() { return _floatTimeUpgradePath.IndexOf(_currentFloatTime); }

    private void Initialize()
    {
        // TODO: Sync with a save file
        _currentTinyMagnet = _tinyMagnetUpgradePath[0];
        _currentFloatTime = _floatTimeUpgradePath[0];
    }
}
