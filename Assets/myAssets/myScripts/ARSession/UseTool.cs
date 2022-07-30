using System.Net.Mime;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient; // database related

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

    // database related
    private string host = "120.77.148.135";
    private string port = "3306";     
    private string userName = "root";
    private string password = "penguinspy123456";
    private string databaseName = "penguintest";
    private MySqlAccess mysql;
    public string myUid;


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

    [SerializeField]
    private GameObject cardSuccess;

    [SerializeField]
    private GameObject cardTorch;

    [SerializeField]
    private GameObject cardHammer;
    
    void Start ()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        // database related
        myUid = GameObject.FindGameObjectWithTag("RegistrationTag").GetComponent<Login>().uid.ToString();
        mysql = new MySqlAccess(host, port, userName, password, databaseName);
        // Debug.Log("Current scene: DummyGameScene. Current userid: " + myUid.ToString());
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

    public void DisplayCard(int cardId)
    {
        dialogueSuccess.SetActive(false);
        dialogueTorch.SetActive(false);
        dialogueHammer.SetActive(false);

        UnityEngine.Debug.Log("show card");
        switch(cardId)
        {
            case 0:
                UnityEngine.Debug.Log("Card1");
                cardSuccess.SetActive(true);
                break;
            case 1:
                UnityEngine.Debug.Log("Card2");
                cardTorch.SetActive(true);
                break;
            case 2:
                UnityEngine.Debug.Log("Card3");
                cardHammer.SetActive(true);
                break;
            default:
                break;
        }
        // databse related
        mysql.OpenSql();
        string query = mysql.Update("userinfo", "penguin" + cardId.ToString(), "1", new string[] { "userid" }, new string[] { "=" }, new string[] { myUid });
        //Debug.Log(query);
        Debug.Log("Congradulation! " + "Uid" + myUid.ToString() + " has " + "penguin" + cardId.ToString() + " now! ");
        MySqlCommand cmd = new MySqlCommand(query, mysql.mySqlConnection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        dataReader.Close();
        mysql.CloseSql();
    }

    public void EndScene()
    {
        UnityEngine.Debug.Log("load end scene");
        SceneManager.LoadScene("G4EndScene");
    }

    public void FailGame()
    {
        UnityEngine.Debug.Log("failed game, back to level choosing");
        SceneManager.LoadScene("GameMenu");        
    }
}
