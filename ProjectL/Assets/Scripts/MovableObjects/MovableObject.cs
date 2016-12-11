using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField]
    protected float multiplier = 1;

    void Update()
    {
        transform.position += Vector3.left * (SpeedController.Instance.Speed * multiplier * Time.deltaTime);
    }
}
