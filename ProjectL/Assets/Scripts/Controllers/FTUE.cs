using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTUE : MonoBehaviour
{
    private const int DISTANCE_JUMP = 10;
    private const int DISTANCE_TEACUPS = 65;
    private const int DISTANCE_ENEMY = 110;
    private const int DISTANCE_JUMP_OFF_ENEMY = 155;
    private const int DISTANCE_WASP = 200;
    private const int DISTANCE_END_TUTORIAL = 250;

    private bool _collectTeacupsShown = false;
    private bool _enemyShown = false;
    private bool _jumpOffEnemy = false;
    private bool _wasp = false;
    private bool _jump = false;
    private bool _endTutorial = false;

    [SerializeField]
    private Animator _fadeToBlack;

    void Update()
    {
        if (!SaveFileManager.Instance.CompletedTutorial)
        {
            if (DistanceController.Instance.Distance >= DISTANCE_JUMP && !_jump)
            {
                _jump = true;
                ShowTutorial(TutorialState.GAME_TAP_TO_JUMP);
            }
            if (DistanceController.Instance.Distance >= DISTANCE_TEACUPS && !_collectTeacupsShown/*&& !SaveFileManager.Instance.TutorialCollectTeacups*/)
            {
                _collectTeacupsShown = true;
                ShowTutorial(TutorialState.GAME_COLLECT_TEACUPS);
            }
            if (DistanceController.Instance.Distance >= DISTANCE_ENEMY && !_enemyShown)
            {
                _enemyShown = true;
                ShowTutorial(TutorialState.GAME_ENEMIES);
            }
            if (DistanceController.Instance.Distance >= DISTANCE_JUMP_OFF_ENEMY && !_jumpOffEnemy)
            {
                _jumpOffEnemy = true;
                ShowTutorial(TutorialState.GAME_JUMP_OFF_ENEMIES);
            }
            if (DistanceController.Instance.Distance >= DISTANCE_WASP && !_wasp)
            {
                _wasp = true;
                ShowTutorial(TutorialState.GAME_DODGE_WASPS);
            }
            if (DistanceController.Instance.Distance >= DISTANCE_END_TUTORIAL && !_endTutorial)
            {
                _endTutorial = true;
                GameController.Instance.CurrentTutorialState = TutorialState.GAME_END_TUTORIAL;
                _fadeToBlack.SetTrigger("FadeToBlack");
                SaveFileManager.Instance.CompleteTutorial();
            }
        }
    }

    private void ShowTutorial(TutorialState tutorialState)
    {
        GameController.Instance.CurrentTutorialState = tutorialState;
        PopupManager.Instance.ShowPopup(Popups.POPOP_TUTORIAL);
    }
}
