using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOpener : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject ToolsParent;
    [SerializeField] GameObject DescriptionParent;
    public void OpenInventory()
    {
        //close all the opening tools
        for (int i = 0; i < ToolsParent.transform.childCount; i++)
        {
        var child = ToolsParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        //close all the opening descriptions.
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }


        if (ToolsParent != null)
        {
            ToolsParent.SetActive(false);
        }

        if (DescriptionParent != null)
        {
            DescriptionParent.SetActive(false);
        }

        if (Inventory != null)
        {
            bool isActive = Inventory.activeSelf;
            Inventory.SetActive(!isActive);
        }

    }
}
