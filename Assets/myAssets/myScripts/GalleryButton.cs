using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryButton : MonoBehaviour
{   public GalleryItem galleryItem;

    void Start()
    {

    }

    public void OnButtonClick()
    {
        if (SceneManager.GetActiveScene().name == "Gallery")
        {
            GameObject.FindGameObjectWithTag("GalleryTag").GetComponent<Gallery2Model>().picid = galleryItem.galleryPenguinPicid;
            SceneManager.LoadScene("Gallery2Model");
            
        }
    }
}
