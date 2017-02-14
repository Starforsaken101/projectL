using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ScoreManager
{
    public const int POINTS_PER_CAT = 20;

    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreManager();
            }
            return _instance;
        }
    }

    private int _points;
    public UnityIntEvent OnScoreUpdated = new UnityIntEvent();

    public void AddPoints(int num)
    {
        _points += num;
        OnScoreUpdated.Invoke(_points);
    }

    public int GetScore()
    {
        return _points;
    }

    public void ResetScore()
    {
        _points = 0;
    }

    public void ConvertPointsToCats()
    {
        int numCats = _points / POINTS_PER_CAT;
        Inventory.Instance.AddCat(numCats);
    }
}
