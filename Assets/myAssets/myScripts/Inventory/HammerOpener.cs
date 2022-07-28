using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerOpener : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ToolsParent;
    public GameObject CloseButton;
    public GameObject ScissorsButton;
    public GameObject HammerButton;
    public GameObject TorchButton;

    public void OpenHammer()
    {
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        Inventory.SetActive(false);
        ToolsParent.SetActive(true);
        HammerButton.SetActive(true);

        ScissorsButton.SetActive(false);
        TorchButton.SetActive(false);        
    }
}
