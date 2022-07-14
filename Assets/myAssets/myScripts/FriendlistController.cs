using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendlistController : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI friendNameText;
    [SerializeField] TextMeshProUGUI friendIndexText;
    [SerializeField] GameObject friendlistBtnPref;
    [SerializeField] Transform friendlistBtnParent;
    [SerializeField] Image friendProfileImage;

    [SerializeField] TextMeshProUGUI friendNameDeleteText;
    [SerializeField] Image friendProfileDeleteImage;
    [SerializeField] GameObject friendlistDeleteWindow;

    public TextAsset jsonFile;
    //public CheckMyFriends checkMyFriends;
    private Dictionary<int, string> friendsName = new Dictionary<int, string>();
    private Dictionary<int, int> friendsPicId = new Dictionary<int, int>();
    private CheckMyFriends checkMyFriends;
    // Start is called before the first frame update
    void Start()
    {
        //checkMyFriends = gameObject.GetComponent<CheckMyFriends>();
        //checkMyFriends.CheckMyFriendsClick();
        
        LoadFriendlistButtons();
        
    }

    private void LoadFriendlistButtons()
    {
        //Friends friends = JsonUtility.FromJson<Friends>(jsonFile.text);
        //Friends friends = checkMyFriends.myFriends;

        checkMyFriends = GameObject.FindGameObjectWithTag("FriendlistTag").GetComponent<CheckMyFriends>();
        checkMyFriends.CheckMyFriendsClick();
        Friends friends = checkMyFriends.myFriends;
        foreach (Friend friend in friends.friends)
        {
            
            GameObject friendlistBtnObj = Instantiate(friendlistBtnPref, friendlistBtnParent) as GameObject;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendIndex = friend.uid;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendName = friend.friendName;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;


            friendlistBtnObj.GetComponentInChildren<FriendlistDeleteButton>().friendIndex = friend.uid;
            friendlistBtnObj.GetComponentInChildren<FriendlistDeleteButton>().friendlistController = this;

            friendsName[friend.uid] = friend.friendName;
            friendsPicId[friend.uid] = friend.picid;
                 
        }
        
    }

    public void OnFriendlistButtonClick(int friendIndex)
    {
        friendNameText.text = friendsName[friendIndex];
        friendIndexText.text = "uid: " + (friendIndex);
        friendProfileImage.sprite = Resources.Load<Sprite>(string.Format("PenguinProfileSamples/profile{0}", friendsPicId[friendIndex]));
        friendProfileImage.SetNativeSize();
    }

    public void OnFriendlistDeleteButtonClick(int friendIndex)
    {
        friendlistDeleteWindow.SetActive(true);
        friendNameDeleteText.text = string.Format("Are you sure to delete\n {0}?", friendsName[friendIndex]);
        friendProfileDeleteImage.sprite = Resources.Load<Sprite>(string.Format("PenguinProfileSamples/profile{0}", friendsPicId[friendIndex]));
        friendProfileDeleteImage.SetNativeSize();
    }
}
