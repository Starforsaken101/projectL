using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _regularSpawners;
    [SerializeField]
    private GameObject _tutorialSpawners;

    void OnEnable()
    {
        if (!SaveFileManager.Instance.CompletedTutorial)
        {
            _tutorialSpawners.SetActive(true);
        }
        else
        {
            _regularSpawners.SetActive(true);
        }
    }
}
