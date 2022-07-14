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
    //private int[] galleryIndicator = {1,1,0,1,1,1};
    private CheckGallery checkGallery;

    // Start is called before the first frame update
    void Start()
    {
        LoadGallery();
    }

    private void LoadGallery()
    {
        checkGallery = GameObject.FindGameObjectWithTag("GalleryTag").GetComponent<CheckGallery>();
        checkGallery.CheckGalleryClick();
        int[] penguinIndicator = checkGallery.myPenguins;
        GalleryPenguins galleriesInJson = JsonUtility.FromJson<GalleryPenguins>(jsonGallery.text);
        int tmpcount = 0;
        foreach (GalleryPenguin penguin in galleriesInJson.galleryPenguinsList)
        {
            if (penguinIndicator[tmpcount] == 1){
              GameObject galleryImgObj = Instantiate(galleryImgPref, galleryImgParent) as GameObject;
              galleryImgObj.GetComponent<GalleryItem>().galleryPenguinIndex = penguin.ind;
              galleryImgObj.GetComponent<GalleryItem>().galleryPenguinName = penguin.penguinName;
              galleryImgObj.GetComponent<GalleryItem>().galleryPenguinPicid = penguin.penguinPicid;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendPicId = friend.picid;
            //friendlistBtnObj.GetComponent<FriendlistButtonItem>().friendlistController = this;
            //friendsName[friend.uid] = friend.friendName;
            //friendsPicId[friend.uid] = friend.picid;
            }
            tmpcount = tmpcount + 1;
        }
    }
}
