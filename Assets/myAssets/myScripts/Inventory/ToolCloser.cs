using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCloser : MonoBehaviour
{
    public GameObject ToolsParent;
    public GameObject ScissorsButton;
    public GameObject HammerButton;
    public GameObject TorchButton;

    public void CloseTool()
    {
        ScissorsButton.SetActive(false);
        HammerButton.SetActive(false);
        TorchButton.SetActive(false);
        ToolsParent.SetActive(false);
    }
}
