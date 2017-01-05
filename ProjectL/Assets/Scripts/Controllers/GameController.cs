using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void ResetControllers()
    {
        ScoreManager.Instance.ResetScore();
        DistanceController.Instance.ResetDistance();
        SpeedController.Instance.ResetSpeedController();
    }

    public void RestartGame()
    {
        ResetControllers();
        SceneController.Instance.LoadScene(SceneController.SCENE_GAME);
    }

    public void BackToMainMenu()
    {
        ResetControllers();
        SceneController.Instance.LoadScene(SceneController.SCENE_MAINMENU);
    }
}
