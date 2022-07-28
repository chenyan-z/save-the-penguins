using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorDescOpener : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject ScissorDesc;
    [SerializeField] GameObject DescriptionParent;

    public void OpenScissorDescription()
    {
        for (int i = 0; i < DescriptionParent.transform.childCount; i++)
        {
        var child = DescriptionParent.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }

        DescriptionParent.SetActive(true);
        Inventory.SetActive(false);
        ScissorDesc.SetActive(true);
    }
}
