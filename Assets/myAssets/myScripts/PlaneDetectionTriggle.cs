using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//to insure the object has the required class when referencing its functions  
[RequireComponent(typeof(ARPlaneManager))] 
public class PlaneDetectionTriggle : MonoBehaviour
{
    [SerializeField]
    private ARPlaneManager planeManager;
    [SerializeField] //able to change the image displayed at runtime
    private Image toggleButtonImg;

    [SerializeField] 
    private Sprite enableButton;

    [SerializeField] 
    private Sprite disableButton;
    
    private void Awake() 
    {
        planeManager = GetComponent<ARPlaneManager>();

    }
        
    //set the plane manager enbaled state to be its current opposite state
    public void TogglePlaneDetection()
    {
        //disable the planeManager, leave the planes visible but to stop updating their sizes and locations 
        //and stop creation of new planes.
        planeManager.enabled = !planeManager.enabled;

        if(planeManager.enabled)
        {
            // UnityEngine.Debug.Log("disable");
            toggleButtonImg.sprite = enableButton;
            SetAllPlaneActive(true);
        }
        else
        {
            // UnityEngine.Debug.Log("enable");
            toggleButtonImg.sprite = disableButton;
            SetAllPlaneActive(false); 
        }

    }

    // enalbe or disable each planes
    private void SetAllPlaneActive(bool value)
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
