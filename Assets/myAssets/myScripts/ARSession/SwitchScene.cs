using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SwitchGameScene (int fromScene)
    {
        switch (fromScene)
        {
            case 0:
                SceneManager.LoadScene("G1FindClue");
                break;
            case 1:
                SceneManager.LoadScene("G2CollectScissors");
                break;
            case 2:
                SceneManager.LoadScene("G3Penguin");
                break;
            case 3:
                SceneManager.LoadScene("G4EndScene");
                break;
            default:
                break;
        }
    }
}
