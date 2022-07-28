using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject Radar;
    public GameObject Magnifier;
    public GameObject Backpack;
    public GameObject Background;
    public GameObject Scissors;

    public void popEndScene()
    {
        Radar.SetActive(false);
        Magnifier.SetActive(false);
        Backpack.SetActive(false);
        Scissors.SetActive(false);
        Background.SetActive(true);
    }
}
