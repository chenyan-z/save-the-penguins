using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue () // function to feed dialogue into the dialogueManager
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // FindObjectOfType<DialogueManager>() uses singleton pattern
    }
}
