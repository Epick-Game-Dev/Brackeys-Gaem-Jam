using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class DialogueManager : MonoBehaviour
{
    private const float TYPING_SPEED = 0.02f;
    private const float OFFSET_CHATBUBBLE_Y = 1.2f;

    private bool nextDialogueKeyDown;
    private bool dialogueStarted;

    [SerializeField]private int index = 0;
    [SerializeField] private bool playerInRange;
    [SerializeField] private GameObject chatBubbleTr;
    [SerializeField] NarratorSO[] dialogues;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject pressEBox;
    [SerializeField] private GameObject puzzle;

    private void Start()
    {
        Transform parentTr = GetComponentInParent<Transform>();
        dialogueText.text = " ";
        chatBubbleTr.transform.position = new Vector3( parentTr.transform.position.x, parentTr.transform.position.y + OFFSET_CHATBUBBLE_Y, parentTr.transform.position.z);
        pressEBox.transform.position = new Vector3(parentTr.transform.position.x, parentTr.transform.position.y + OFFSET_CHATBUBBLE_Y, parentTr.transform.position.z);
        chatBubbleTr.SetActive(false);
        pressEBox.SetActive(false);
        dialogueStarted = false;
        playerInRange = false;
    }

    private void Update()
    {
        nextDialogueKeyDown = Input.GetKeyDown(KeyCode.E);
        if (playerInRange && nextDialogueKeyDown && !dialogueStarted)
        {
            chatBubbleTr.SetActive(true);
            dialogueStarted = true;
            pressEBox.SetActive(false);
            StartCoroutine(TypingCoroutine());
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            index = 0;
            playerInRange = true;
            pressEBox.SetActive(true);
        }
    }

    private void EndDialogue()
    {
        index = 0;
        chatBubbleTr.SetActive(false);
        playerInRange = true;
        dialogueStarted = false;
        StopAllCoroutines();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            index = 0;
            chatBubbleTr.SetActive(false);
            pressEBox.SetActive(false);
            playerInRange = false;
            dialogueStarted = false;
            StopAllCoroutines();
        }
    }

    IEnumerator TypingCoroutine()
    {
        foreach (NarratorSO dialogue in dialogues)
        {

            StringBuilder toShow = new StringBuilder(dialogues[index].narration);
            bool skippingTags = false;
            for (int i = 0; i < toShow.Length; i++)
            {
                if (dialogues[index].narration[i] == '<')
                {
                    skippingTags = true;
                    continue;
                }

                if (dialogues[index].narration[i] == '>')
                {
                    skippingTags = false;
                    continue;
                }

                if (skippingTags)
                    continue;
                toShow[i] = ' ';
            }
            skippingTags = false;
            for (int i = 0; i < toShow.Length; i++)
            {
                if (dialogues[index].narration[i] == '<')
                {
                    skippingTags = true;
                    continue;
                }

                if (dialogues[index].narration[i] == '>')
                {
                    skippingTags = false;
                    continue;
                }
                if (skippingTags)
                    continue;
                toShow[i] = dialogues[index].narration[i];
                dialogueText.text = toShow.ToString();
                yield return new WaitForSeconds(TYPING_SPEED);
            }
            yield return new WaitUntil(() => nextDialogueKeyDown);
            dialogueText.text = " ";
            index++;
        }
        if (puzzle != null)
        {
            puzzle.SetActive(true);
        }
        EndDialogue();
    }
}
