using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryManager : MonoBehaviour
{
    public string uid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void myGallery()
    {
        //Debug.Log("Moo");
        GameObject.FindGameObjectWithTag("RegistrationTag").GetComponent<GalleryManager>().uid = GameObject.FindGameObjectWithTag("RegistrationTag").GetComponent<Login>().uid.ToString();
    }

}
