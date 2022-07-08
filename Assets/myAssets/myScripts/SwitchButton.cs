using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchButton : MonoBehaviour
{
    public int galleryCount = 0;
    public GameObject galleryObj1;
    public GameObject galleryObj2;
    public void SwitchDisplay()
    {
        if (galleryCount == 0) {
          galleryObj1.SetActive(false);
          galleryObj2.SetActive(true);
          galleryCount = 1;
        }
        else {
          galleryObj2.SetActive(false);
          galleryObj1.SetActive(true);
          galleryCount = 0;
        }
    }
}
