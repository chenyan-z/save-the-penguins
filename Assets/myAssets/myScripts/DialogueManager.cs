using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // chenyan don't know why I only have TextMeshPro object (no text) in my unity object
             // forcing me using TMPro to drag to inspector

public class DialogueManager : MonoBehaviour
{

    // for UI

    public TextMeshProUGUI nameText;     // to drag to inspector, matching TextMeshPro object
    public TextMeshProUGUI dialogueText;

    // others

    public Queue<string> sentences;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        // show GameObject DialogueBox
        FindObjectOfType<HideShow>().ShowObject(dialogueBox);

        // start dialogue
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence () // called by StartDialogue / continue button
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        // Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue ()
    {
        // hide GameObject DialogueBox
        FindObjectOfType<HideShow>().HideObject(dialogueBox);

        // end dialogue
        Debug.Log("End of conversation.");
    }
}
