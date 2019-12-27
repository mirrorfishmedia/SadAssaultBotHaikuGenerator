using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Haiku : MonoBehaviour
{
    public WordKnower wordKnower;
    public TextDisplayer textDisplayer;

    private Word veryFirstWord;
    private Word currentWord;
    private Word lastWord;

    void Start()
    {
        currentWord = wordKnower.GetRandomWord();

    }

    public void Update()
    {
        
        if (Input.GetButtonUp("Jump"))
        {
            lastWord = currentWord;
            GeneratePoem();
        }
    }

    public void GeneratePoem()
    {
        Debug.Log("<color=green>line 0 :</color>" + GenerateLine(5));
        Debug.Log("<color=green>line 1 :</color>" + GenerateLine(7));
        Debug.Log("<color=green>line 2 :</color>" + GenerateLine(5));
        Debug.Log("   " );
        Debug.Log("   " );
        Debug.Log("   " );

        string textToDisplay = GenerateLine(5) + ",\n" + GenerateLine(7) + ",\n" + GenerateLine(5) + ".";

        textToDisplay = char.ToUpper(textToDisplay[0]) + textToDisplay.Substring(1);

        textDisplayer.DisplayText(textToDisplay);
    }

    public string GenerateLine(int targetSyllables)
    {
        string generatedLineText = "";
        int currentSyllables = 0;
        int loopCount = 0;
        int maxLoop = 99999;

        while (currentSyllables < targetSyllables && loopCount < maxLoop)
        {
            if (currentSyllables <= 3)
            {
                lastWord = wordKnower.GetChainedWord(currentWord, false);

            }
            else
            {
                lastWord = wordKnower.GetChainedWord(currentWord, true);
            }

            currentWord = lastWord;
            if (currentWord.syllableCount + currentSyllables <= targetSyllables)
            {
                generatedLineText += (" " + currentWord.wordCharacters);
                currentSyllables += currentWord.syllableCount;
            }
            
            loopCount++;
        }
        return generatedLineText;
    }
}


