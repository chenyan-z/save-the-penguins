using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendlistButtonItem : MonoBehaviour
{

    [HideInInspector] public int friendIndex;
    [HideInInspector] public string friendName;
    //[HideInInspector] public int friendPicId;
    [HideInInspector] public FriendlistController friendlistController;

    [SerializeField] TextMeshProUGUI friendNameText;

    private void Start()
    {
        friendNameText.text = friendName;
    }

    public void OnFriendlistButtonClick()
    {
        friendlistController.OnFriendlistButtonClick(friendIndex);
    }
}
