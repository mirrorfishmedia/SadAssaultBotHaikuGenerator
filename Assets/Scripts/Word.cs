using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Poetry/Word")]
public class Word : ScriptableObject
{
    public string wordCharacters;
    public int syllableCount;
    public enum WordClass
    {
        noun, verb, adjective, adverb, preposition, determiner, exclamation, conjunction 
    };

    public WordClass wordClass;
    
}


