using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsOpener : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ToolsParent;
    public GameObject CloseButton;
    public GameObject ScissorsButton;
    public GameObject HammerButton;
    public GameObject TorchButton;

    public void OpenScissors()
    {
        Inventory.SetActive(false);
        ToolsParent.SetActive(true);
        CloseButton.SetActive(true);
        ScissorsButton.SetActive(true);

        HammerButton.SetActive(false);
        TorchButton.SetActive(false);
    }
}
