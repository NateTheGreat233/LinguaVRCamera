using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//Defines each individual text box, temporary data storage on UI
public class TextBox : MonoBehaviour
{

    [SerializeField] bool priority = true;
    private TextMeshPro tmpro;
    private List<string> words = new List<string>();

    private TimeStamps timeStamps;

    private TimeSpan createTime;

    public void InitializeTextBox(List<string> assignWords, bool priority)
    { 
        createTime = timeStamps.GetCurrentTime();

        tmpro.text = createTime.ToString();

        words.Clear();

        foreach(string word in assignWords)
        {
            words.Add(word);
        }
    }

    public void RevealWords()
    {
        tmpro.text = string.Join(" ", words);
    }

    public TimeSpan GetTextBoxCreateTime()
    {
        return createTime;
    }

    public void ClearTextBox()
    {
        priority = true;
        words.Clear();
        createTime = TimeSpan.Zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeStamps = FindObjectOfType<TimeStamps>();
    }

}
