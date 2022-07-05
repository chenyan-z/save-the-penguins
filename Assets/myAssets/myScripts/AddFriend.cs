using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFriend : MonoBehaviour
{
    public void AddNewFriend(GameObject friendToCopy)
    {
      GameObject newFriend = GameObject.Instantiate(friendToCopy);
      newFriend.transform.SetParent(friendToCopy.transform.parent, false);
      newFriend.SetActive(true);
    }
}
