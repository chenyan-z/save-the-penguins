using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FriendlistGalleryButton : MonoBehaviour
{
    // Start is called before the first frame update
    public FriendlistButtonItem friendlistButtonItem;
    void Start()
    {
        
    }
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Gallery");
        GameObject.FindGameObjectWithTag("RegistrationTag").GetComponent<GalleryManager>().uid = friendlistButtonItem.friendIndex.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
