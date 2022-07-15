using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchButtonController : MonoBehaviour
{
    // friend uid to search
    public InputField frienduidSearchText;

    // friend information to be displayed if search is successful.
    [SerializeField] TextMeshProUGUI friendNameText;
    [SerializeField] TextMeshProUGUI friendIndexText;
    [SerializeField] Image friendProfileImage;

    //searchUser
    private SearchUser searchUser;


    public void OnSearchButtonClick()
    {
        string uidText = frienduidSearchText.text;
        //Debug.Log(uidText);
        searchUser = GameObject.FindGameObjectWithTag("SearchTag").GetComponent<SearchUser>();
        searchUser.searchUid = frienduidSearchText;
        searchUser.SearchUserClick();
        Friend searchResult = searchUser.searchFriend;
        friendNameText.text = searchResult.friendName;
        friendIndexText.text = "uid: "+(searchResult.uid).ToString();
        friendProfileImage.sprite = Resources.Load<Sprite>(string.Format("PenguinProfileSamples/profile{0}", searchResult.picid));
        friendProfileImage.SetNativeSize();
    }
        /*checkMyFriends.CheckMyFriendsClick();
        Friends friends = checkMyFriends.myFriends;
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

    // Start is called before the first frame update
/*    void Start()
    {
        //checkMyFriends = gameObject.GetComponent<CheckMyFriends>();
        //checkMyFriends.CheckMyFriendsClick();

        LoadFriendlistButtons();

    }*/

    /*private void LoadFriendlistButtons()
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

    }*/
}
