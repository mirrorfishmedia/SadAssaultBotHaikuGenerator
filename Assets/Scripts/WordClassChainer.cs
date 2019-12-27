using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordClassChainer : MonoBehaviour {

    public WordKnower wordKnower;
    

    public Word ConnectWord(Word inputWord, bool isLastWord)
    {

        Word foundWord;
        List<Word[]> possibleWordArrays = new List<Word[]>();

        switch (inputWord.wordClass)
        {
            case Word.WordClass.noun:
                possibleWordArrays.Add(wordKnower.conjunctions);
                possibleWordArrays.Add(wordKnower.prepositions);
                possibleWordArrays.Add(wordKnower.verbs);
                possibleWordArrays.Add(wordKnower.adverbs);
                possibleWordArrays.Add(wordKnower.exclamations);
                possibleWordArrays.Add(wordKnower.adjectives);

                break;
            case Word.WordClass.verb:

                possibleWordArrays.Add(wordKnower.adverbs);
                possibleWordArrays.Add(wordKnower.adjectives);
                possibleWordArrays.Add(wordKnower.nouns);

                break;
            case Word.WordClass.adjective:
                possibleWordArrays.Add(wordKnower.nouns);

                break;
            case Word.WordClass.adverb:
                possibleWordArrays.Add(wordKnower.conjunctions);
                possibleWordArrays.Add(wordKnower.prepositions);
                possibleWordArrays.Add(wordKnower.nouns);
                possibleWordArrays.Add(wordKnower.verbs);

                break;
            case Word.WordClass.preposition:
                possibleWordArrays.Add(wordKnower.nouns);
                break;

            case Word.WordClass.determiner:
                
                possibleWordArrays.Add(wordKnower.nouns);
                possibleWordArrays.Add(wordKnower.adjectives);

                break;
            case Word.WordClass.exclamation:

                possibleWordArrays.Add(wordKnower.exclamations);
                possibleWordArrays.Add(wordKnower.nouns);
                possibleWordArrays.Add(wordKnower.verbs);
                possibleWordArrays.Add(wordKnower.adjectives);
                possibleWordArrays.Add(wordKnower.determiners);
                break;
            case Word.WordClass.conjunction:
                
                possibleWordArrays.Add(wordKnower.nouns);
                possibleWordArrays.Add(wordKnower.adjectives);
                break;
            default:

                Debug.Log("default on wordclass");
                break;
        }

        Word[] foundWordClass = possibleWordArrays[Random.Range(0, possibleWordArrays.Count)];

       

        foundWord = foundWordClass[Random.Range(0, foundWordClass.Length)];

        if (isLastWord)
        {
           foundWord = wordKnower.GetEndWord();
        }

        return foundWord;
    }
    
}
