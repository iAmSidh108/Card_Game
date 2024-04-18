using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Container : MonoBehaviour
{
    public bool isBeingUsed=false;
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
