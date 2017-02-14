using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Experimental.Director;

public class UILosePopup : UIPopup
{
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private TextMeshProUGUI _cats;
    [SerializeField]
    private TextMeshProUGUI _yarnAddedText;
    [SerializeField]
    private Animator _yarnAnimator;
    [SerializeField]
    private AnimationClip _yarnClip;

    private float duration = 0.85f;
    private int _yarn = 0;
    private int _yarnAdded = 0;
    private int _currentScore = 0;

    void OnEnable()
    {
        _yarnAdded = 0;
        _yarnAddedText.alpha = 0;
        _currentScore = ScoreManager.Instance.GetScore();
        StartCoroutine(LerpScore(ScoreManager.Instance.GetScore(), 0, _score));
        _yarn = Inventory.Instance.TotalCats();
        _cats.text = _yarn.ToString();
        ScoreManager.Instance.ConvertPointsToCats();
    }

    public void Restart()
    {
        GameController.Instance.RestartGame();
        ClosePopup();
    }

    public void OnMainMenu()
    {
        GameController.Instance.BackToMainMenu();
    }

    private IEnumerator LerpScore(int start, int target, TextMeshProUGUI text)
    {
        int current = 0;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            current = (int)Mathf.Lerp(start, target, progress);

            if (current + ScoreManager.POINTS_PER_CAT <= _currentScore)
            {
                _currentScore = current;
                _yarnAdded += 1;
                _yarn += 1;
                _cats.text = ": " + _yarn.ToString();

                if (_yarnAddedText.alpha == 0)
                {
                    _yarnAddedText.alpha = 1;
                }

                _yarnAddedText.text = "+" + _yarnAdded.ToString();
                var clipPlayable = AnimationClipPlayable.Create(_yarnClip);
                _yarnAnimator.Play(clipPlayable);

                SoundManager.Instance.PlaySFX(Utils.SFX_COLLECT_TEACUP, 0.2f);
            }

            text.text = ": " + current.ToString();
            yield return null;
        }
        text.text = ": 0";
    }
}
