using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILosePopup : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _cats;

    void OnEnable()
    {
        ScoreManager.Instance.ConvertPointsToCats();

        _score.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
        _cats.text = "Cats: " + Inventory.Instance.TotalCats().ToString();
    }

    public void Restart()
    {
        GameController.Instance.RestartGame();
        gameObject.SetActive(false);
    }
}
