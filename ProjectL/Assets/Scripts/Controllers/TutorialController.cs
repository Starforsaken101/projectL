using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TutorialState
{
    NONE = 0,
    DEATH_BY_FALL,
    DEATH_BY_SPIDER,
    DEATH_BY_SNAIL,
    DEATH_BY_WASP,
    SHOP_UPGRADE_TINY_MAGNET,
    SHOP_UPGRADE_FLOAT_TIME,
    SHOP_UPGRADE_CATCHUP_SPEED,
    GAME_TAP_TO_JUMP,
    GAME_COLLECT_TEACUPS,
    GAME_JUMP_OFF_ENEMIES,
    GAME_ENEMIES,
    GAME_DODGE_WASPS,
    GAME_END_TUTORIAL
}

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textTutorial;

    void OnEnable()
    {
        SetTutorialText();
    }

    private void SetTutorialText()
    {
        _textTutorial.text = GameController.Instance.GetStringForTutorialState();
    }
}
