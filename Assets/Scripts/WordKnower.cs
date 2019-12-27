using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordKnower : MonoBehaviour {


    public WordClassChainer wordClassChainer;
    public Word[] nouns;
    public Word[] verbs;
    public Word[] adjectives;
    public Word[] adverbs;
    public Word[] prepositions;
    public Word[] determiners;
    public Word[] exclamations;
    public Word[] conjunctions;

    public List<Word> allWordsList = new List<Word>();
    public List<Word> endWordsList = new List<Word>();

    //noun, verb, adjective, adverb, preposition, determiner, exclamation, conjunction 
    private void Awake()
    {
        nouns = Resources.LoadAll<Word>("Words/Nouns");
        verbs = Resources.LoadAll<Word>("Words/Verbs");
        adjectives = Resources.LoadAll<Word>("Words/Adjectives");
        adverbs = Resources.LoadAll<Word>("Words/Adverbs");
        prepositions = Resources.LoadAll<Word>("Words/Prepositions");
        determiners = Resources.LoadAll<Word>("Words/Determiners");
        exclamations = Resources.LoadAll<Word>("Words/Exclamations");
        conjunctions = Resources.LoadAll<Word>("Words/Conjunctions");

        allWordsList.AddRange(nouns);
        allWordsList.AddRange(verbs);
        allWordsList.AddRange(adjectives);
        allWordsList.AddRange(adverbs);
        allWordsList.AddRange(prepositions);
        allWordsList.AddRange(determiners);
        allWordsList.AddRange(exclamations);
        allWordsList.AddRange(conjunctions);

        endWordsList.AddRange(nouns);
    }

    public Word GetEndWord()
    {
        return endWordsList[Random.Range(0, endWordsList.Count)];
    }

    public Word GetRandomWord()
    {
        return allWordsList[Random.Range(0, allWordsList.Count)];
    }

    public Word GetChainedWord(Word currentWord, bool isLastWord)
    {
        return wordClassChainer.ConnectWord(currentWord, isLastWord);
    }

}
