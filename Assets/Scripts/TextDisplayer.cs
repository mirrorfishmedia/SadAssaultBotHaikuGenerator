using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour {

    public Text displayText;

    public void DisplayText(string incomingText)
    {
        displayText.text = incomingText;
    }
    
}
