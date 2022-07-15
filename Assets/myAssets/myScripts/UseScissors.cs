using System.Net.Mime;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))] 
[RequireComponent(typeof(ARPlaneManager))] 
public class UseScissors : MonoBehaviour
{

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private GameObject objPenguinRope;
    private bool saved = false;
    private Vector2 touchPosition = default;

    [SerializeField]
    private PlacementIndicator placementIndicator;

    [SerializeField] 
    private GameObject scissorsToApply; // change objects

    [SerializeField]
    private GameObject thePenguinWithRope;

    [SerializeField]
    private GameObject theSavedPenguin;

    
    void Start ()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update() 
    {
        // if(planeManager.enabled)
        // {
            if(objPenguinRope == null && saved == false && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                UnityEngine.Debug.Log("enter if");
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                touchPosition = Input.GetTouch(0).position;
                raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds);
                if(hits.Count > 0){
                    objPenguinRope = Instantiate(thePenguinWithRope, hits[0].pose.position, hits[0].pose.rotation);
                }
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinBounds);
            }
            
        // }
        
    }    
    public void ApplyScissors()
    {
        // LeanTweenExt.LeanMoveLocal(scissorsToApply, placementIndicator.transform.position,1).setEaseOutQuart().setLoopPingPong(1);
        //scissorsToApply.transform.LeanMoveLocal(placementIndicator.transform.position,0.5).setEaseOutQuart().setLoopPingPong(1);
        UnityEngine.Debug.Log("tap scissors");
        saved = true;
        ReplaceObjects(objPenguinRope);          
      
    }

    private void ReplaceObjects(GameObject objs)
    {
        UnityEngine.Debug.Log("try to replace");
        Instantiate(theSavedPenguin, objs.transform.position, objs.transform.rotation);
        Destroy(objs);
    }
}
