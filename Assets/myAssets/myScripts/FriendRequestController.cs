using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendRequestController : MonoBehaviour
{
    private string[] tmpstr = {"Guoba", "Guobaba", "Guobababa"};
    [SerializeField] TextMeshProUGUI requestName;
    [SerializeField] GameObject requestPref;
    [SerializeField] Transform requestParent;

    // Start is called before the first frame update
    void Start()
    {
        LoadRequest();
    }


    private void LoadRequest()
    {
        foreach (string tmpname in tmpstr)
        {
            GameObject requestObj = Instantiate(requestPref, requestParent) as GameObject;
            requestObj.GetComponent<RequestItem>().requestFriendName = tmpname;
            //galleryImgObj.GetComponent<GalleryItem>().galleryPenguinName = penguin.penguinName;
            //galleryImgObj.GetComponent<GalleryItem>().galleryPenguinPicid = penguin.penguinPicid;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendPicId = friend.picid;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;
            //friendsName[friend.uid] = friend.friendName;
            //friendsPicId[friend.uid] = friend.picid;
        }
    }
}
