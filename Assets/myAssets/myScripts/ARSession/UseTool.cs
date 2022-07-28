using System.Net.Mime;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARRaycastManager))] 
[RequireComponent(typeof(ARPlaneManager))] 
public class UseTool : MonoBehaviour
{

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private GameObject objPenguinRope;
    

    private bool saved = false; // only used scissors can save the penguin
    private bool applied = false;
    public int CardId = -1; //default value, 0:happy penguin, 1: fire penguin, 2: hit penguin

    private Vector2 touchPosition = default;

    // private GameObject toolToApply;

    [SerializeField]
    private PlacementIndicator placementIndicator;

    [SerializeField] 
    private GameObject toolsToApply; 

    [SerializeField]
    private GameObject thePenguinWithRope;

    [SerializeField]
    private GameObject[] theSavedPenguin;

    [SerializeField]
    private GameObject[] penguinCards;

    [SerializeField]
    private GameObject penguinOnFireCard;

    [SerializeField]
    private GameObject dialogueSuccess;

    [SerializeField]
    private GameObject dialogueTorch;

    [SerializeField]
    private GameObject dialogueHammer;
    
    void Start ()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update() 
    {
            if(objPenguinRope == null && saved == false && applied == false && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // UnityEngine.Debug.Log("enter if");
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
    }

    public void ApplyTool()
    {
        // LeanTweenExt.LeanMoveLocal(scissorsToApply, placementIndicator.transform.position,1).setEaseOutQuart().setLoopPingPong(1);
        //scissorsToApply.transform.LeanMoveLocal(placementIndicator.transform.position,0.5).setEaseOutQuart().setLoopPingPong(1);

        UnityEngine.Debug.Log("tap tool");  
        if(GameObject.Find("ScissorsButton") != null)
        {       
            UnityEngine.Debug.Log("use Scissors");
            CardId = 0;
            saved = true;
        }
        else if(GameObject.Find("TorchButton") != null)
        {
            UnityEngine.Debug.Log("use Torch");
            CardId = 1;
            saved = false;
        }
        else if(GameObject.Find("HammerButton") != null)
        {
            UnityEngine.Debug.Log("use Hammer");
            CardId = 2;
            saved = false;
        }
        else
        {
            return;
        }
        applied = true; // already used a tool, cannot place another penguin.
        ReplaceObjects(objPenguinRope, CardId); 
        TalkCaptain(CardId);
        
    }

    private void ReplaceObjects(GameObject objs, int penguinId)
    {
        UnityEngine.Debug.Log("try to replace");
        // Instantiate(happyPenguin, objs.transform.position, objs.transform.rotation);
        switch(penguinId)
        {
            case 0:
                UnityEngine.Debug.Log("win the game");
                Instantiate(theSavedPenguin[0], objs.transform.position, objs.transform.rotation);
                break;
            case 1:
                UnityEngine.Debug.Log("fail 1");
                Instantiate(theSavedPenguin[1], objs.transform.position, objs.transform.rotation);
                break;
            case 2:
                UnityEngine.Debug.Log("fail 2");
                Instantiate(theSavedPenguin[2], objs.transform.position, objs.transform.rotation);
                break;
            default:
                break;
        }
        Destroy(objs);
        // SceneManager.LoadScene("G4EndScene");
    }

    private void TalkCaptain(int endingId)
    {
        UnityEngine.Debug.Log("talk to captain");
        switch(endingId)
        {
            case 0:
                UnityEngine.Debug.Log("talk & win the game");
                dialogueSuccess.SetActive(true);
                break;
            case 1:
                UnityEngine.Debug.Log("talk & fail 1");
                dialogueTorch.SetActive(true);
                break;
            case 2:
                UnityEngine.Debug.Log("talk & fail 2");
                dialogueHammer.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void DisplayCard(int cardId)
    {
        UnityEngine.Debug.Log("show card");
        switch(cardId)
        {
            case 0:
                UnityEngine.Debug.Log("Card1");
                break;
            case 1:
                UnityEngine.Debug.Log("Card2");
                break;
            case 2:
                UnityEngine.Debug.Log("Card3");
                break;
            default:
                break;
        }
    }

    // public function to change scene
}
