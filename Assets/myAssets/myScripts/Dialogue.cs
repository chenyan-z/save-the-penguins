using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue // our class to hold needed values in a dialogue
{
    public string name;

    [TextArea(3,10)] // each string sentence will have a text field of (3, 10) lines
    public string[] sentences;
}
