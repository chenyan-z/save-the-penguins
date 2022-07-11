using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SpwanObjectOnPlane : MonoBehaviour
{
    // Start is called before the first frame update
    private ARRaycastManager raycastManager;
    private GameObject spwanedObject;
    public GameObject placeablePrefab;
    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Awake() {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    //to check if there is a touch
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            UnityEngine.Debug.Log("detect touch");
            return true;
        }
        touchPosition = default;
        UnityEngine.Debug.Log("cannot detect touch");
        return false;
    }
    private void Update() 
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return; //if no touch, don't place anything
        }
        if(raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            UnityEngine.Debug.Log("Placing Object");
            var hitPos = hits[0].pose;
            if(spwanedObject == null)
            {
                spwanedObject = Instantiate(placeablePrefab, hitPos.position, hitPos.rotation);
            }
            else
            {
                spwanedObject.transform.position = hitPos.position;
                spwanedObject.transform.rotation = hitPos.rotation;
            }
        }
    }
}
