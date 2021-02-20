using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HappinessManager : MonoBehaviour
{
    public static HappinessManager Instance { get { return instance; } }
    public static HappinessManager instance = null;

    [SerializeField] TextMeshProUGUI happinessText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateHappiness();
    }

    public void UpdateHappiness()
    {
        happinessText.text = "Happiness: " + PlayerStats.currentHappiness.ToString();
    }


}
