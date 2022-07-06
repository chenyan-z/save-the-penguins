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
    public TextAsset jsonFile;
    private Dictionary<int, string> friendsName = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        LoadFriendlistButtons();
    }

    private void LoadFriendlistButtons()
    {
        // naive implementation: hard code the friendlist
        //for (int i = 0; i < 10; i ++)
        //{
        //    GameObject friendlistBtnObj = Instantiate(friendlistBtnPref, friendlistBtnParent) as GameObject;
        //    friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendIndex = i;
        //    friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;
        //}

        Friends friendsInJson = JsonUtility.FromJson<Friends>(jsonFile.text);
        foreach (Friend friend in friendsInJson.friends)
        {
            GameObject friendlistBtnObj = Instantiate(friendlistBtnPref, friendlistBtnParent) as GameObject;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendIndex = friend.uid;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendName = friend.friendName;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendPicId = friend.picid;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;
            friendsName[friend.uid] = friend.friendName;

        }
    }

    public void OnFriendlistButtonClick(int friendIndex)
    {
        friendNameText.text = friendsName[friendIndex];
        friendIndexText.text = "uid: " + (friendIndex);
    }
}
