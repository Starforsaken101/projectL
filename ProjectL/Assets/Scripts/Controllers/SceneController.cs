using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    [StringValue("GameScene")]
    GAMESCENE,
    [StringValue("MainMenu")]
    MAIN_MENU,
    [StringValue("Shop")]
    SHOP
}

public class SceneController
{
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

    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(StringEnum.GetStringValue(scene));
    }
}
