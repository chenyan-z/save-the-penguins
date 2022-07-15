using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerOpener : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ToolsParent;
    public GameObject CloseButton;
    public GameObject HammerButton;

    public void OpenHammer()
    {
        Inventory.SetActive(false);
        ToolsParent.SetActive(true);
        CloseButton.SetActive(true);
        HammerButton.SetActive(true);
    }
}
