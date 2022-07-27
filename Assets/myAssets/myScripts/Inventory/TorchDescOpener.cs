using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDescOpener : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject TorchDesc;
    [SerializeField] GameObject DescriptionParent;

    public void OpenTorchDescription()
    {
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        DescriptionParent.SetActive(true);
        Inventory.SetActive(false);
        TorchDesc.SetActive(true);
    }
}
