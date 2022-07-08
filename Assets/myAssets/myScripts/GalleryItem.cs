using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryItem : MonoBehaviour
{

    [HideInInspector] public int galleryPenguinIndex;
    [HideInInspector] public string galleryPenguinName;
    [HideInInspector] public int galleryPenguinPicid;

    [SerializeField] TextMeshProUGUI galleryPenguinNameText;
    [SerializeField] Image galleryPenguinImage;

    private void Start()
    {
        galleryPenguinNameText.text = galleryPenguinName;
        galleryPenguinImage.sprite = Resources.Load<Sprite>(string.Format("GalleryImgs/profile{0}", galleryPenguinPicid));
        galleryPenguinImage.SetNativeSize();
    }
}
