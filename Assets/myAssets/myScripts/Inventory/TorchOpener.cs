using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOpener : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject ToolsParent;
    [SerializeField] GameObject TorchButton;
    [SerializeField] GameObject DescriptionParent;

    public void OpenTorch()
    {
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        Inventory.SetActive(false);
        ToolsParent.SetActive(true);
        TorchButton.SetActive(true);
    }
}