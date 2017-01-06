using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClothingController : MonoBehaviour
{
    [SerializeField]
    private GameObject _hair;
    [SerializeField]
    private GameObject _hairAccessory;
    [SerializeField]
    private GameObject _top;
    [SerializeField]
    private GameObject _bottom;
    [SerializeField]
    private GameObject _shoes;

    void Awake()
    {
        Toggle("Hair");
    }

    public void Toggle(string name)
    {
        CompareComponent(name, _hair);
        CompareComponent(name, _hairAccessory);
        CompareComponent(name, _top);
        CompareComponent(name, _bottom);
        CompareComponent(name, _shoes);
    }

    private void CompareComponent(string name, GameObject go)
    {
        if (go.name == name)
            go.SetActive(true);
        else
            go.SetActive(false);
    }
}
