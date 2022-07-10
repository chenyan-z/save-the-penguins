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
    private Dictionary<int, string> friendsName = new Dictionary<int, string>();
    private Dictionary<int, int> friendsPicId = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        LoadFriendlistButtons();
    }

    private void LoadFriendlistButtons()
    {
        Friends friendsInJson = JsonUtility.FromJson<Friends>(jsonFile.text);
        foreach (Friend friend in friendsInJson.friends)
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
