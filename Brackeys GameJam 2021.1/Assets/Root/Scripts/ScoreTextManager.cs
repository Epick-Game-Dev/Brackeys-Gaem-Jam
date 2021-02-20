using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = $"Congratulations, you've finished the game! \n You gained a total of {PlayerStats.currentHappiness} happiness of a maximum {PlayerStats.maxHappiness} \n You are the best! ";
    }
}
