using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject Canvas;
    
    public GameObject Background;

    public void popEndScene()
    {
        for (int i = 0; i < Canvas.transform.childCount; i++)
        {
        var child = Canvas.transform.GetChild(i).gameObject;
        if (child != null)
            child.SetActive(false);
        }
        
        Background.SetActive(true);
    }
}
