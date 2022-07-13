using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager rayManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject visual;

    void Start ()
    {
        // get the components
        visual = transform.GetChild(0).gameObject;

        // hide the placement visual
        visual.SetActive(false);
    }

    void Update ()
    {
        // shoot a raycast from the center of the screen
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

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
}