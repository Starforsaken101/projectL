using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICatsHud : MonoBehaviour
{
    [SerializeField]
    private Text _hudText;

    void Awake()
    {
        UpdateHudText(Inventory.Instance.TotalCats().ToString());
        Inventory.Instance.OnCatsUpdated.AddListener(OnCatsUpdate);
    }

    private void OnCatsUpdate(int x)
    {
        UpdateHudText(x.ToString());
    }

    private void UpdateHudText(string text)
    {
        _hudText.text = text;
    }
}
