using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlistDeleteButton : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public int friendIndex;
    [HideInInspector] public FriendlistController friendlistController;
    
    void Start()
    {
        
    }

    public void OnFriendlistDeleteButtonClick()
    {
        friendlistController.OnFriendlistDeleteButtonClick(friendIndex);
    }
}
