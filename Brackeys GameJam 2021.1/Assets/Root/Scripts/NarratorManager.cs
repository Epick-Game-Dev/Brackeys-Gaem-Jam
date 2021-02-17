using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class NarratorManager: MonoBehaviour
{
    private const float TYPING_SPEED = 0.1f;

    [SerializeField] private float timeBetweenText;
    [SerializeField] NarratorSO[] narrations;
    [SerializeField] TextMeshProUGUI narrationText;

    IEnumerator Start()
    {
        foreach (NarratorSO narration in narrations)
        {

            StringBuilder toShow = new StringBuilder(narration.narration);
            bool skippingTags = false;
            for (int i = 0; i < toShow.Length; i++)
            {
                if (narration.narration[i] == '<')
                {
                    skippingTags = true;
                    continue;
                }

                if (narration.narration[i] == '>')
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
                if (narration.narration[i] == '<')
                {
                    skippingTags = true;
                    continue;
                }

                if (narration.narration[i] == '>')
                {
                    skippingTags = false;
                    continue;
                }
                if (skippingTags)
                    continue;
                toShow[i] = narration.narration[i];
                narrationText.text = toShow.ToString();
                yield return new WaitForSeconds(TYPING_SPEED); // Change for typing speed
            }
            yield return new WaitForSeconds(timeBetweenText);
        }
        
    }


}
