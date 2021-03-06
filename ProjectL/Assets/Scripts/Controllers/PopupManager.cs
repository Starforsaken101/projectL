﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Popups
{
    [StringValue("popup-lose")]
    POPUP_LOSE,
    [StringValue("popup-tutorial")]
    POPOP_TUTORIAL,
    [StringValue("popup-end-tutorial")]
    POPUP_END_TUTORIAL
}

public class PopupManager
{
    private static PopupManager _instance;
    public static PopupManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PopupManager();
            }
            return _instance;
        }
    }

    public PopupEvent OnShowPopup = new PopupEvent();

    public void ShowPopup(Popups popupName)
    {
        OnShowPopup.Invoke(popupName);
    }
}
