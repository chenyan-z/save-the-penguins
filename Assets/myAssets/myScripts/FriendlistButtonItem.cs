using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendlistButtonItem : MonoBehaviour
{

    [HideInInspector] public int friendIndex;
    [HideInInspector] public FriendlistController friendlistController;

    [SerializeField] TextMeshProUGUI friendNameText;

    private void Start()
    {
        friendNameText.text = "Spy" + (friendIndex);
    }

    public void OnFriendlistButtonClick()
    {
        friendlistController.OnFriendlistButtonClick(friendIndex);
    }
}
