using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupController : MonoBehaviour
{
    private const string PATH_PREFIX = "Prefabs/Popups/";

    void Awake()
    {
        PopupManager.Instance.OnShowPopup.AddListener(OnShowPopup);
    }

    private void OnShowPopup(Popups popupName)
    {
        string popup = StringEnum.GetStringValue(popupName);

        GameObject popupGO = Utils.InstantiateGameObjectByPath(PATH_PREFIX + popup);
        if (popupGO == null)
        {
            Debug.LogError("UIPopupController: Could not show popup of name " + popup + " because it does not exist!");
        }

        popupGO.transform.SetParent(gameObject.transform, false);
    }    
}
