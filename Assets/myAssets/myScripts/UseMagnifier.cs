using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMagnifier : MonoBehaviour
{
    public float lastSpawnTime;
    private PlacementIndicator placementIndicator;
    [SerializeField] 
    private GameObject magnifierToApply;
    [SerializeField]
    private GameObject objectToSpawn;
    void Start ()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }
    public void ApplyMagnifier()
    {
        UnityEngine.Debug.Log("start move");
        magnifierToApply.transform.LeanMoveLocal(placementIndicator.transform.position,1).setEaseOutQuart().setLoopPingPong(1);
        if(Time.time >= lastSpawnTime + 5f) //spawn footprint after 5s since last placement
        {
            UnityEngine.Debug.Log("try to place");
            lastSpawnTime = Time.time;
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }
}
