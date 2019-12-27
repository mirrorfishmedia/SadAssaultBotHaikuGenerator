using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Poetry/Concept")]
public class Concept : ScriptableObject
{
    public Word[] words;
    public enum grammarType
    {
        Noun,Verb,Adjective
    };
}
