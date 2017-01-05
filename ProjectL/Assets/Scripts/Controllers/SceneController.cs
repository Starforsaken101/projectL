using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    [StringValue("GameScene")]
    GAMESCENE,
    [StringValue("MainMenu")]
    MAIN_MENU
}

public class SceneController
{
    public static string SCENE_GAME = "Gamescene";
    public static string SCENE_MAINMENU = "MainMenu";

    private static SceneController _instance;
    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneController();
            }
            return _instance;
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
