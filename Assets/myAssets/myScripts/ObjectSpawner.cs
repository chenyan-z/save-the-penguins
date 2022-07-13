using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    private ARPlaneManager planeManager;

    void Start ()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        planeManager = FindObjectOfType<ARPlaneManager>();
    }

    void Update ()
    {
        // if(planeManager.enabled)
        // {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {   
                GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            }
        // }
        
    }
}
