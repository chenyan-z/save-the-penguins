using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI penguinNameText;
    [SerializeField] GameObject galleryImgPref;
    [SerializeField] Transform galleryImgParent;
    [SerializeField] Image penguinImage;
    public TextAsset jsonGallery;
    private Dictionary<int, string> penguinsName = new Dictionary<int, string>();
    private Dictionary<int, int> penguinsPicId = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        LoadGallery();
    }

    private void LoadGallery()
    {
        GalleryPenguins galleriesInJson = JsonUtility.FromJson<GalleryPenguins>(jsonGallery.text);
        foreach (GalleryPenguin penguin in galleriesInJson.galleryPenguinsList)
        {
            GameObject galleryImgObj = Instantiate(galleryImgPref, galleryImgParent) as GameObject;
            galleryImgObj.GetComponent<GalleryItem>().index = penguin.ind;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendName = friend.friendName;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendPicId = friend.picid;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;
            //friendsName[friend.uid] = friend.friendName;
            //friendsPicId[friend.uid] = friend.picid;
        }
    }
}
