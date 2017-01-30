using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEndTutorial : MonoBehaviour
{
    public void DisplayPopup()
    {
        PopupManager.Instance.ShowPopup(Popups.POPUP_END_TUTORIAL);
    }
}
