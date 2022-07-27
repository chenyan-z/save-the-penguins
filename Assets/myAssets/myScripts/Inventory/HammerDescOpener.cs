using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDescOpener : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject HammerDesc;
    [SerializeField] GameObject DescriptionParent;

    public void OpenHammerDescription()
    {
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        DescriptionParent.SetActive(true);
        Inventory.SetActive(false);
        HammerDesc.SetActive(true);
    }
}
