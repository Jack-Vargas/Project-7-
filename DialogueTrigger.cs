using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool ready;
    public GameObject GameManager;
    public DialogueManager Script;

    [Header("InkJSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake()
    {
        Script = GameManager.GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (ready == true && Input.GetKeyDown(KeyCode.E))
        {
           if (Script.DialogueUp == false) 
           {
                StartCoroutine(Wait());
           }
            
        }
    }

    private void OnTriggerEnter2D()
    {
        ready = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ready = true;
    }

    public IEnumerator Wait()
    {
        yield return new WaitForEndOfFrame();
        Script.StartDialogue(inkJSON);
    }
}
