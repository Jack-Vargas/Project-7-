using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public GameObject Player;

    public GameObject SpeachBubble;
    public Text text;
    public bool DialogueUp;

    private Story currentStory;

    public GameObject[] choices;
    public Text[] choicesText;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (instance != null)
        {

        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        DialogueUp = false;
        SpeachBubble.SetActive(false);

        choicesText = new Text[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<Text>();
            index++;
        }
    }

    private void Update()
    {
        if (!DialogueUp)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueDialogue();
        }
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        Player.GetComponent<PlayerMovement>().enabled = false;

        currentStory = new Story(inkJSON.text);

        SpeachBubble.SetActive(true);
        DialogueUp=true;

        ContinueDialogue();
    }

    public void EndDialogue()
    {
        SpeachBubble.SetActive(false);
        StartCoroutine(Wait());
        text.text = "";
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    void ContinueDialogue()
    {
        if (currentStory.canContinue)
        {
           text.text = currentStory.Continue();
           DisplayChoices();
        }
        else
        {
            EndDialogue();
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForEndOfFrame();
        DialogueUp = false;
    }

    public void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("notEnoughButtons");
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }


    public void MakeChoice(int choiceIndex)
    {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueDialogue();
    }
}
