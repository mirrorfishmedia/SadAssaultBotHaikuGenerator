using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class WordCreator : ScriptableWizard {


    public string wordCharacters;
    public Word.WordClass newWordClass;

    [MenuItem("Assets/WordCreator")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<WordCreator>("Create Word", "Create", "Create With Count");
        //If you don't want to use the secondary button simply leave it out:
        //ScriptableWizard.DisplayWizard<WizardCreateLight>("Create Light", "Create");
    }

    private void OnWizardCreate()
    {
        Debug.Log("use the other button");
    }

    private void OnWizardOtherButton()
    {
        CreateAsset();

    }

    private int CountSyllables(string word)
    {
        word = word.ToLower().Trim();
        bool lastWasVowel = false;
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'y' };
        int count = 0;

        //a string is an IEnumerable<char>; convenient.
        foreach (var c in word)
        {
            if (vowels.Contains(c))
            {
                if (!lastWasVowel)
                    count++;
                lastWasVowel = true;
            }
            else
                lastWasVowel = false;
        }

        if ((word.EndsWith("e") || (word.EndsWith("es") || word.EndsWith("ed")))
              && !word.EndsWith("le"))
            count--;

        return count;
    }

    public void CreateAsset()
    {
        Word newWord = ScriptableObject.CreateInstance<Word>();
        newWord.wordCharacters = wordCharacters;
        newWord.syllableCount = CountSyllables(wordCharacters);
        newWord.wordClass = newWordClass;

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + wordCharacters + ".asset");

        AssetDatabase.CreateAsset(newWord, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newWord;
    }
}
