using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryItem : MonoBehaviour
{

    [HideInInspector] public int index;
    [HideInInspector] public string galleryPenguinName;

    [SerializeField] TextMeshProUGUI galleryPenguinNameText;

    private void Start()
    {
        //galleryPenguinNameText.text = galleryPenguinName;
    }
}
