using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIDistanceController : MonoBehaviour
{
    private TextMeshProUGUI _distanceText;

    void Awake()
    {
        _distanceText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        DistanceController.Instance.AddToDistance(SpeedController.Instance.GetDeltaTime(Time.deltaTime * 10));
        _distanceText.text = Mathf.Floor(DistanceController.Instance.Distance).ToString();
    }
}
