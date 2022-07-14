using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestItem : MonoBehaviour
{

    [HideInInspector] public string requestFriendName;
    [SerializeField] TextMeshProUGUI requestNameText;

    private void Start()
    {
        requestNameText.text = requestFriendName;
    }
}
