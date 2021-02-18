using System;
using System.Collections.Generic;
using UnityEngine;

public class KanoodleSlot : MonoBehaviour
{
    public SlotStatesEnum slotStatesEnum;
    private KanoodlePuzzle kanoodlePuzzle;

    private void Awake()
    {
        kanoodlePuzzle = GetComponentInParent<KanoodlePuzzle>();
    }

    public void UpdateSlots()
    {
        kanoodlePuzzle.UpdateSlotsToWin();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (slotStatesEnum == SlotStatesEnum.Snapped)
        {
            return;
        }
        if (other.CompareTag("Piece"))
        {
            slotStatesEnum = SlotStatesEnum.Full;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (slotStatesEnum == SlotStatesEnum.Snapped)
        {
            return;
        }
        if (other.CompareTag("Piece"))
        {
            slotStatesEnum = SlotStatesEnum.Empty;
        }
    }


}