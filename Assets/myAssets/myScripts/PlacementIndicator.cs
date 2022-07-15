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
    
    [SerializeField]
    ARRaycastManager rayManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    //used for manipulate existing ar objects
    // private PlacementObjects[] placedObjects;
    // private PlacementObjects lastSelectedObject;
    // private Vector2 touchPosition = default;

    void Start ()
    {
        // get the components
        // rayManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();
        // detectoinTriggle = FindObjectOfType<PlaneDetectionTriggle>();
        visual = transform.GetChild(0).gameObject;
        planeManager = FindObjectOfType<ARPlaneManager>();

        // hide the placement visual
        visual.SetActive(false);
    }

    void Update ()
    {
        if(planeManager.enabled) // clue-detection mode
        {
            // shoot a raycast from the center of the screen
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
            else // object-interaction mode
            {
                visual.SetActive(false);
            }
        }
    }
}
