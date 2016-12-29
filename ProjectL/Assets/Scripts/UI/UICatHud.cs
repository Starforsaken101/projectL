using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICatHud : MonoBehaviour
{
    [SerializeField]
    private Text _hudText;

    void Awake()
    {
        Inventory.Instance.OnCatsUpdated.AddListener(OnInventoryUpdate);
    }

    private void OnInventoryUpdate(int x)
    {
        UpdateHudText(x.ToString());
    }

    private void UpdateHudText(string text)
    {
        _hudText.text = text;
    }
}
