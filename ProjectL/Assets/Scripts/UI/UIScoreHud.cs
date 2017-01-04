using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreHud : MonoBehaviour
{
    [SerializeField]
    private Text _hudText;

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
