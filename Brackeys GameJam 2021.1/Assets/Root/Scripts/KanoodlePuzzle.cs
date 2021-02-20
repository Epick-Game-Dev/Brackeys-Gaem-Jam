using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanoodlePuzzle : MonoBehaviour
{
    [SerializeField] private int piecesToWin;
    [SerializeField] private PieceController[] pieces;
    [SerializeField] private Animator fade;

    private void Awake()
    {
        piecesToWin++;
        StartCoroutine(UpdateSlotsToWin());
    }

    public IEnumerator UpdateSlotsToWin()
    {
        piecesToWin--;
        if (piecesToWin <= 0)
        {
            PlayerStats.currentHappiness += 2;
            HappinessManager.Instance.UpdateHappiness();
            Debug.Log("You Win!");
            yield return new WaitForSeconds(1);
            fade.SetBool("Fade Out", true);
            yield return new WaitForSeconds(0.5f);
            SceneManagement.LoadPointsCountScene();
        }
        else
        {
            Debug.Log($"{piecesToWin} pieces left to win.");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (var piece in pieces)
            {
                piece.transform.position = piece.originalPosition;
                piece.pieceStatesEnum = PieceStatesEnum.Free;
            }
            foreach (Transform slot in transform)
            {
                KanoodleSlot kanoodleSlot = slot.GetComponent<KanoodleSlot>();
                kanoodleSlot.slotStatesEnum = SlotStatesEnum.Empty;
            }
            piecesToWin = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}