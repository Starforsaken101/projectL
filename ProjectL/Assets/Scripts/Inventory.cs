using UnityEngine;

public class Inventory
{
    private static Inventory _instance;
    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }
    }

    private Inventory()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        _cats = SaveFileManager.Instance.NumCats;
    }

    private int _cats = 0;
    public UnityIntEvent OnCatsUpdated = new UnityIntEvent();

    public void AddCat(int numCats)
    {
        _cats += numCats;
        OnCatsUpdated.Invoke(_cats);
        SaveFileManager.Instance.NumCats = _cats;
    }

    public int TotalCats()
    {
        return _cats;
    }

    public void SpendCats(int num)
    {
        if (_cats >= num)
        {
            _cats -= num;
            OnCatsUpdated.Invoke(_cats);
            SaveFileManager.Instance.NumCats = _cats;
        }
    }
}
