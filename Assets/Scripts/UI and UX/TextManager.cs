using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

// Manages transcripted text (that shows up above face)
public class TextManager : MonoBehaviour
{
    [SerializeField] GameObject transcription;
   
    private TextMeshPro transcriptText;
    private Settings settingsManager;
    private TimeStamps timeStamps;
    private Settings settings;


    private int wordOverflowCount;
    private int wordsSavedCount;

    [SerializeField] List<TextBox> textBoxes = new List<TextBox>();

    private int counter = 0;

    List<string> words = new List<string>();

    public void AddWord(string newWord)
    {
        if(newWord.Contains(" ")){
           
            string[] newWords = newWord.Split(null);
           
            foreach (string word in newWords)
            {
                words.Add(word);
            }

        }

        transcriptText.text = string.Join(" ", words);

        CheckWordCount();
    }

    void CheckWordCount() //declutter transcription text
    {
        if (words.Count > wordOverflowCount)
        {
            List<string> deletedWords = words.GetRange(0, wordsSavedCount - 1);

            if (counter < 8)
            {
                textBoxes[counter].InitializeTextBox(deletedWords, settingsManager.GetPriority());
                counter += 1;
            }
            else
            {
                counter = 0;
                textBoxes[counter].InitializeTextBox(deletedWords, settingsManager.GetPriority());
            }


            words.RemoveRange(0, wordsSavedCount - 1);
        }
    }

    public void HideUI(bool hide)
    {
        gameObject.SetActive(!hide);
    }

    public void RequestTranscript(float time) //request for certain transcript at any point in time
    {
        foreach(TextBox textBox in textBoxes)
        {
            TimeSpan difference = timeStamps.GetCurrentTime().Subtract(textBox.GetTextBoxCreateTime());
            
            if(difference.Minutes < time)
            {
                textBox.RevealWords();
                break;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transcriptText = transcription.GetComponent<TextMeshPro>();
        settingsManager = gameObject.GetComponent<Settings>();
        timeStamps = gameObject.GetComponent<TimeStamps>();
        settings = gameObject.GetComponentInChildren<Settings>();

        wordOverflowCount = settings.GetWordOverflowCount();
        wordsSavedCount = settings.GetWordsSavedCount();
    }

}
