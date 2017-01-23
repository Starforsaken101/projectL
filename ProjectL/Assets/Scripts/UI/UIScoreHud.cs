using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScoreHud : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _hudText;

    void Awake()
    {
        ScoreManager.Instance.OnScoreUpdated.AddListener(OnScoreUpdate);
    }

    private void OnScoreUpdate(int x)
    {
        UpdateHudText(x.ToString());
    }

    private void UpdateHudText(string text)
    {
        _hudText.text = text;
    }
}
