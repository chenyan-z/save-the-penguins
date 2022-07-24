using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject Map;
    public GameObject Magnifier;
    public GameObject Backpack;
    public GameObject Background;

    public void popEndScene()
    {
        Map.SetActive(false);
        Magnifier.SetActive(false);
        Backpack.SetActive(false);
        Background.SetActive(true);
    }
}
