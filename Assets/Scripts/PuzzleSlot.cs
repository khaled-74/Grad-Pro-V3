using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    private List<PuzzlePiece> pieces;

    public bool allSnapped(List<PuzzlePiece> piece)
    {
        foreach (PuzzlePiece _piece in piece)
        {
            if (!_piece.snapped)
                return false;
        }

        return true;
    }
}
