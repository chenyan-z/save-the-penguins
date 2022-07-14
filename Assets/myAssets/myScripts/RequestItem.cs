using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestItem : MonoBehaviour
{

    [HideInInspector] public string requestFriendName;
    [SerializeField] TextMeshProUGUI requestNameText;
    public InputField requestUidText;
    public Friend curRequestFriend;

    private void Start()
    {
        requestNameText.text = requestFriendName;
    }
}
