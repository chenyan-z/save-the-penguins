using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOpener : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ToolsParent;
    public GameObject CloseButton;
    public GameObject ScissorsButton;
    public GameObject HammerButton;
    public GameObject TorchButton;

    public void OpenTorch()
    {
        Inventory.SetActive(false);
        ToolsParent.SetActive(true);
        CloseButton.SetActive(true);
        TorchButton.SetActive(true);

        ScissorsButton.SetActive(false);
        HammerButton.SetActive(false); 
    }
}
