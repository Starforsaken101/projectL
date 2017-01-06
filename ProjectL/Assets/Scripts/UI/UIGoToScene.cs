using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGoToScene : MonoBehaviour
{
    [SerializeField]
    private Scenes _scene;

    public void GoToScene()
    {
        SceneController.Instance.LoadScene(_scene);
    }
}
