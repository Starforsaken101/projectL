using UnityEngine.Events;

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

    public UnityIntEvent OnCatsUpdated = new UnityIntEvent();

    private int _cats = 0;

    public void AddCat(int numCats)
    {
        _cats += numCats;
        OnCatsUpdated.Invoke(_cats);
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
        }
    }
}
