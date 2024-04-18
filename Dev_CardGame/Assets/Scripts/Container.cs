using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Container : MonoBehaviour
{
    [Header("Flags")]
    public bool isBeingUsed = false;

    [Header("UI")]
    public TextMeshProUGUI groupLabel;

    private void Start()
    {
       groupLabel.text = gameObject.name;
    }

    private void Update()
    {
        if (transform.childCount < 2)
        {
            isBeingUsed = false;
            groupLabel.gameObject.SetActive(false);
        }
        else
        {
            isBeingUsed = true;
            groupLabel.gameObject.SetActive(true);
        }
    }
}
