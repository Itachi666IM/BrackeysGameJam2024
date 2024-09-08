using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StoryTextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] string[] sentences;
    private int index = 0;
    [SerializeField] float typingSpeed = 0.02f;
    private GameObject storyCanvas;
    [SerializeField] GameObject continueButton;
    void Start()
    {
        storyCanvas = GameObject.Find("Story Canvas");
        StartCoroutine(StoryTyper());
    }

    IEnumerator StoryTyper()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            gameText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    private void Update()
    {
        if(gameText.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            gameText.text = "";
            StartCoroutine(StoryTyper());
        }
        else
        {
            gameText.text = "";
            continueButton.SetActive(false);
            storyCanvas.SetActive(false);
        }
    }
}
