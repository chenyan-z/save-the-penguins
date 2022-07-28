using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCard : MonoBehaviour
{
    public GameObject PenguinCard;

    public void CloseCardContent()
    {
        UnityEngine.Debug.Log("click");
        PenguinCard.SetActive(false);
    }
}
