using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARModelController : MonoBehaviour
{
    private GameObject MyObject;
    private int picid;
    public ARRaycastManager RaycastManager;

    private void Start()
    {
        picid = GameObject.FindGameObjectWithTag("GalleryTag").GetComponent<Gallery2Model>().picid;
        MyObject = Resources.Load<GameObject>(string.Format("3DPrefabs/prefab{0}", (picid % 2) + 1)); // mod 2 since currently only two prefabs
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> touches = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touches.Count > 0) GameObject.Instantiate(MyObject, touches[0].pose.position, touches[0].pose.rotation);
        }
    }
}
