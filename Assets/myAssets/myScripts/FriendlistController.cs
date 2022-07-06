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

    // Start is called before the first frame update
    void Start()
    {
        LoadFriendlistButtons();
    }

    private void LoadFriendlistButtons()
    {
        // naive implementation: hard code the friendlist
        for (int i = 0; i < 10; i ++)
        {
            GameObject friendlistBtnObj = Instantiate(friendlistBtnPref, friendlistBtnParent) as GameObject;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendIndex = i;
            friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;
        }
    }

    public void OnFriendlistButtonClick(int friendIndex)
    {
        friendNameText.text = "Spy" + (friendIndex);
        friendIndexText.text = "uid: " + (friendIndex);
    }
}
