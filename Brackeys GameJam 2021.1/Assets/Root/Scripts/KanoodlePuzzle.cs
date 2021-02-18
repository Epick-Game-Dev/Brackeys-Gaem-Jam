﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanoodlePuzzle : MonoBehaviour
{
    [SerializeField] private int slotsToWin;
    [SerializeField] private Transform[] slots;

    private void Awake()
    {
        UpdateSlotsToWin();
    }

    public void UpdateSlotsToWin()
    {
        int count = 0;
        foreach (Transform slot in slots)
        {
            KanoodleSlot kanoodleSlot = slot.GetComponent<KanoodleSlot>();
            if (kanoodleSlot.slotStatesEnum != SlotStatesEnum.Snapped)
            {
                count++;
            }

        }
        slotsToWin = count;
        Debug.Log("Slots to win: " + count);
        if (slotsToWin <= 0)
        {
            Debug.Log("You won!");
        }
    }
}