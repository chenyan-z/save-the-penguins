using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeclineAndDestroy : MonoBehaviour
{
    public GameObject requestToDestroy;
    public void DeclineClick()
    {
        Destroy (requestToDestroy);
    }
}
