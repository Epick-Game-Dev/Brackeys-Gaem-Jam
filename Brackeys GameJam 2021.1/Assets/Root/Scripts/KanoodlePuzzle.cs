using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanoodlePuzzle : MonoBehaviour
{
    [SerializeField] private int piecesToWin;
    [SerializeField] private PieceController[] pieces;

    private void Awake()
    {
        piecesToWin++;
        UpdateSlotsToWin();
    }

    public void UpdateSlotsToWin()
    {
        piecesToWin--;
        if (piecesToWin <= 0)
        {
            Debug.Log("You Win!");
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
        }
    }
}