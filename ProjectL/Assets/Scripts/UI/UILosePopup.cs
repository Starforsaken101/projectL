using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILosePopup : UIPopup
{
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private TextMeshProUGUI _cats;

    void OnEnable()
    {
        ScoreManager.Instance.ConvertPointsToCats();

        _score.text = ": " + ScoreManager.Instance.GetScore().ToString();
        _cats.text = ": " + Inventory.Instance.TotalCats().ToString();
    }

    public void Restart()
    {
        GameController.Instance.RestartGame();
        ClosePopup();
    }
}
