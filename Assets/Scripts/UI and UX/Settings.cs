using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//for settings panel- TODO: create in engine! 
public class Settings : MonoBehaviour
{

    [SerializeField] bool priority = true;

    [SerializeField] int wordOverflowCount = 50;
    [SerializeField] int wordsSavedCount = 20;

    public bool GetPriority()
    {
        return priority;
    }
    public void SetPriority(bool isPriority)
    {
        priority = isPriority;
    }

    public int GetWordOverflowCount()
    {
        return wordOverflowCount;
    }

    public void SetWordOverflowCount(int count)
    {
        wordOverflowCount = count;
    }

    public int GetWordsSavedCount()
    {
        return wordsSavedCount;
    }

    public void SetWordsSavedCount(int count)
    {
        wordsSavedCount = count;
    }

    public void SetColor(TextMeshPro text, Color rgb)
    {
        text.color = rgb;
    }

}
