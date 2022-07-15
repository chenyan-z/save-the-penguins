using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARPlaneManager planeManager;
    private ARRaycastManager rayManager;
    private GameObject visual;
    
    //used for manipulate existing ar objects
    // private PlacementObjects[] placedObjects;
    // private PlacementObjects lastSelectedObject;
    // private Vector2 touchPosition = default;

    // [SerializeField]
    // private Camera arCamera;
    void Start ()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();
        // detectoinTriggle = FindObjectOfType<PlaneDetectionTriggle>();
        visual = transform.GetChild(0).gameObject;

        // hide the placement visual
        visual.SetActive(false);
    }

    void Update ()
    {   
        if(planeManager.enabled) // clue-detection mode
        {
            // shoot a raycast from the center of the screen
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinBounds);
            // if we hit an AR plane, update the position and rotation
            if (hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;

                if (!visual.activeInHierarchy)
                {
                    visual.SetActive(true);
                }
            }
        }
        else // object-interaction mode
        {
            visual.SetActive(false);
        }
    }


    // void Update ()
    // {
    //     // shoot a raycast from the center of the screen
    //     List<ARRaycastHit> hits = new List<ARRaycastHit>();
    //     rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinBounds);

    //     // if we hit an AR plane, update the position and rotation
    //     if (hits.Count > 0)
    //     {
    //         if(planeManager.enabled)
    //         {
    //             // UnityEngine.Debug.Log("planeManager enable");
    //             transform.position = hits[0].pose.position;
    //             transform.rotation = hits[0].pose.rotation;

    //             if (!visual.activeInHierarchy)
    //             {
    //                 // UnityEngine.Debug.Log("set visual active");
    //                 visual.SetActive(true);
    //             }

    //             //if the user touch the screen
    //             // if (Input.touchCount > 0)
    //             // {
    //             //     Touch touch = Input.GetTouch(0);
    //             //     touchPosition = touch.position;
    //             //     if(touch.phase == TouchPhase.Began)
    //             //     {
    //             //         Ray ray = arCamera.ScreenPointToRay(touch.position);
    //             //         RaycastHit hitObject;
    //             //         if(Physics.Raycast(ray, out hitObject))
    //             //         {
    //             //             lastSelectedObject = hitObject.transform.GetComponent<PlacementObjects>();
    //             //             if(lastSelectedObject != null)
    //             //             {
    //             //                 PlacementObjects[] allOtherObjects = FindObjectsOfType<PlacementObjects>();
    //             //                 foreach(PlacementObjects placementObjects in allOtherObjects)
    //             //                 {
    //             //                     placementObjects.Selected = placementObjects == lastSelectedObject;
    //             //                 }
    //             //             }
    //             //         }
    //             //     } 
    //             //     if(touch.phase == TouchPhase.Ended)
    //             //     {
    //             //         lastSelectedObject.Selected = false;
    //             //     }
    //             // }
    //         }
    //         else
    //         {
    //             // UnityEngine.Debug.Log("Set cursor disable");
    //             visual.SetActive(false);
    //         }
    //     }
    // }
}