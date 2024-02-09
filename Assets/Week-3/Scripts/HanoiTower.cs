using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    private int[] peg1 = { 1, 2, 3, 4 };
    private int[] peg2 = { 0, 0, 0, 0 };
    private int[] peg3 = { 0, 0, 0, 0 };

    private int currentPeg = 1;

    void MoveRight()
    {
        if (CanMoveRight() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg + 1);
        int toIndex = GetBottomNumberIndex(toArray);

        if ( toIndex == -1) return;

        MoveNumber(fromArray, fromIndex, toArray, toIndex);
    }

    void MoveLeft()
    {
        if (CanMoveLeft() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg - 1);
        int toIndex = GetBottomNumberIndex(toArray);

        if (toIndex == -1) return;

        MoveNumber(fromArray, fromIndex, toArray, toIndex);
    }

    void MoveNumber(int[] fromArray, int fromIndex, int[] toArray, int toIndex)
    {
        int value = fromArray[fromIndex];
        fromArray[fromIndex] = 0;

        toArray[toIndex] = value;
    }

    bool CanMoveRight()
    {
        return currentPeg < 3;
    }

    bool CanMoveLeft()
    {
        return currentPeg > 1;
    }

    int[] GetPeg(int pegNumber)
    {
        if (pegNumber == 1) return peg1;

        if (pegNumber == 2) return peg2;

        return peg3;

    }

    int GetTopNumberIndex(int[] peg)
    {
        for (int i = 0; i < peg.Length; i++)
        {
            if (peg[i] != 0) return i;
        }

        return -1;
    }

    int GetBottomNumberIndex(int[] peg)
    {
        for (int i = peg.Length - 1; i >= 0; i--)
        {
            if (peg[i] == 0) return i;
        }

        return -1;
    }
}
