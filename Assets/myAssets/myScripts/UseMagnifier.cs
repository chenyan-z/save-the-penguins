using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UseMagnifier : MonoBehaviour
{
    public float lastSpawnTime;

    [SerializeField]
    private int countObject;

    [SerializeField]
    private ARPlaneManager planeManager;

    [SerializeField]
    private PlacementIndicator placementIndicator;

    [SerializeField] 
    private GameObject magnifierToApply;

    // [SerializeField] 
    // private GameObject scissorsToApply; // change objects

    [SerializeField]
    private GameObject footprintClue;

    [SerializeField]
    private GameObject toolClue;

    public bool toolFound; // TODO: use later

    
    void Start ()
    {
        toolFound = false;
        countObject = 0;
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        planeManager = FindObjectOfType<ARPlaneManager>();
    }

    //magnifier (can be changed)
    public void ApplyMagnifier()
    {
        magnifierToApply.transform.LeanMoveLocal(placementIndicator.transform.position,1).setEaseOutQuart().setLoopPingPong(1);
        // -------TO DO later: add pobability manager to set probability for the object to be generated
        if(Time.time >= lastSpawnTime + 5f && countObject < 4) //spawn footprint after 5s since last placement
        {
        // -------TO DO later: add pop out chat box to notify user to open the detector to find the footprints.
            lastSpawnTime = Time.time;
            SpawnObjects(footprintClue);
            countObject = countObject + 1;           
        }
        else if (countObject == 4) // show the discovered tool to the user
        {
            toolFound = true;
            SpawnObjects(toolClue);
        }
    }

    private void SpawnObjects(GameObject objs)
    {
        if(planeManager.enabled)
        {
            UnityEngine.Debug.Log("try to place" + countObject);
            GameObject obj = Instantiate(objs, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
        
    }
}
