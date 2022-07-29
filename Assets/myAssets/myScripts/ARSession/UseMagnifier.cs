using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class UseMagnifier : MonoBehaviour
{
    public float lastSpawnTime;
    public bool hinted;
    public int countObject;

    [SerializeField]
    private ARPlaneManager planeManager;

    [SerializeField]
    private PlacementIndicator placementIndicator;

    [SerializeField] 
    GameObject magnifierToApply;
    [SerializeField]
    private GameObject hintToSpawn;
    [SerializeField]
    private GameObject footprintClue;
    [SerializeField]
    private GameObject objectToSpawn;

    private GameObject spawnedObject;
    private GameObject spawnedHint;
    Camera arCam;

    [SerializeField]
    ARRaycastManager rayManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    void Start ()
    {
        countObject = 0;
        hinted = false;
        spawnedHint = null;
    }

    void Update ()
    {
        if (Input.touchCount == 0)
            return;
        
        // on touch:
        // use magnifier to place the hint.
        // if (!hinted && Input.GetTouch(0).phase == TouchPhase.Began){ // if not hinted yet, generate hint
        //     UnityEngine.Debug.Log("try to place hint");
        //     hinted = true;
        //     spawnedHint = Instantiate(hintToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        //     return;
        // }
        
        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
        if (rayManager.Raycast(Input.GetTouch(0).position, hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Scissors")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        UnityEngine.Debug.Log("try to destroy hint and drag object");
                        Destroy(spawnedHint); // destroy hint before spawning tool
                        spawnedHint = null;
                        spawnedObject = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
                        UnityEngine.Debug.Log("object spawned");
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = hits[0].pose.position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended){
                Destroy(spawnedObject);
                spawnedObject = null;
                
                // TODO: object collected!
                // SceneManager.LoadScene("G3Penguin");
            }
        }
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
        else if (countObject == 4) //start to generate highlights
        {
            spawnedHint = Instantiate(hintToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            hinted = true;
            countObject = countObject + 1;
        }
        // SceneManager.LoadScene("G2CollectScissors");
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
