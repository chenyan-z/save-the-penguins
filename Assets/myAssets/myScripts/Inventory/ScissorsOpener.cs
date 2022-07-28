using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsOpener : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject ToolsParent;
    [SerializeField] GameObject ScissorsButton;
    [SerializeField] GameObject DescriptionParent;

    public void OpenScissors()
    {
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        Inventory.SetActive(false);
        ToolsParent.SetActive(true);
        ScissorsButton.SetActive(true);
    }
}
