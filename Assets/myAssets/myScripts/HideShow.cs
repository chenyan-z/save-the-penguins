using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShow : MonoBehaviour
{
    public void HideObject (GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ShowObject (GameObject obj)
    {
        obj.SetActive(true);
    }
}
