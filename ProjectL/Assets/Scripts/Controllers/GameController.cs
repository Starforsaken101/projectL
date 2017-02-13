using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameController();
            }
            return _instance;
        }
    }

    private GameController()
    {
        _tutorialText.Add(TutorialState.DEATH_BY_FALL, "Tap the screen to jump!");
        _tutorialText.Add(TutorialState.DEATH_BY_SPIDER, "Spiders are nasty buggers. Jump on them to kill them!");
        _tutorialText.Add(TutorialState.DEATH_BY_SNAIL, "Snails loooove you. Dodge them away");
        _tutorialText.Add(TutorialState.DEATH_BY_WASP, "I didn't know you liked wasps that much. Avoid them to stay alive.");
        _tutorialText.Add(TutorialState.DEATH_BY_TRAP, "Thorns are gonna f*&k you up");

        _tutorialText.Add(TutorialState.SHOP_UPGRADE_CATCHUP_SPEED, "This upgrade effects how fast it takes you to catch up if you fall back a little!");
        _tutorialText.Add(TutorialState.SHOP_UPGRADE_FLOAT_TIME, "This upgrade will whisk you up, up, and away!");
        _tutorialText.Add(TutorialState.SHOP_UPGRADE_TINY_MAGNET, "This upgrade makes you positively magnetic");

        _tutorialText.Add(TutorialState.GAME_TAP_TO_JUMP, "Tap the screen to jump!");
        _tutorialText.Add(TutorialState.GAME_JUMP_OFF_ENEMIES, "You can jump off an enemy right after it dies!");
        _tutorialText.Add(TutorialState.GAME_COLLECT_TEACUPS, "Collect teacups off the map so you can give them to meeeee :D");
        _tutorialText.Add(TutorialState.GAME_DODGE_WASPS, "JUST DODGE THESE OMG");
        _tutorialText.Add(TutorialState.GAME_ENEMIES, "Jump on an enemy to KILL IT!");
        _tutorialText.Add(TutorialState.GAME_END_TUTORIAL, "Spend that hard-earned dough, girlllll");
    }

    private Dictionary<TutorialState, string> _tutorialText = new Dictionary<TutorialState, string>();

    private TutorialState _currentTutorialState = TutorialState.NONE;
    public TutorialState CurrentTutorialState
    {
        get { return _currentTutorialState; }
        set { _currentTutorialState = value; }
    }

    public string GetStringForTutorialState()
    {
        return GetStringForTutorialState(_currentTutorialState);
    }

    public string GetStringForTutorialState(TutorialState tutorialState)
    {
        if (_tutorialText.ContainsKey(tutorialState))
        {
            return _tutorialText[tutorialState];
        }
        return "";
    }

    private void ResetControllers()
    {
        ScoreManager.Instance.ResetScore();
        DistanceController.Instance.ResetDistance();
        SpeedController.Instance.ResetSpeedController();
    }

    public void RestartGame()
    {
        ResetControllers();
        SceneController.Instance.LoadScene(Scenes.GAMESCENE);
    }

    public void BackToMainMenu()
    {
        ResetControllers();
        SceneController.Instance.LoadScene(Scenes.MAIN_MENU);
    }

    public void PauseGame(bool isPause)
    {
        if (isPause)
        {
            SpeedController.Instance.Speed = 0;
        }
        else
        {
            SpeedController.Instance.ResetSpeedController(false);
        }
    }
}
