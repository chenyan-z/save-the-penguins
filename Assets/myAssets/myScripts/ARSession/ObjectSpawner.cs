using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager rayManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    GameObject hintToSpawn;
    GameObject spawnedHint;
    bool hinted;

    [SerializeField]
    GameObject objectToSpawn;
    GameObject spawnedObject;

    Camera arCam;
    private PlacementIndicator placementIndicator;

    void Start ()
    {
        hinted = false;
        spawnedHint = null;
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        // rayManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update ()
    {
        if (Input.touchCount == 0)
            return;
        
        // on touch:

        if (!hinted && Input.GetTouch(0).phase == TouchPhase.Began){ // if not hinted yet, generate hint
            UnityEngine.Debug.Log("try to place hint");
            hinted = true;
            spawnedHint = Instantiate(hintToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            return;
        }
        
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
                SceneManager.LoadScene("G3Penguin");
            }
        }
    }
}