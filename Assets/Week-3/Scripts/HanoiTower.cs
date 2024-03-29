using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    [SerializeField] private Transform peg1Transform;
    [SerializeField] private Transform peg2Transform;
    [SerializeField] private Transform peg3Transform;
    [SerializeField] GameObject pegIndicator1;
    [SerializeField] GameObject pegIndicator2;
    [SerializeField] GameObject pegIndicator3;
    [SerializeField] GameObject winLabel;

    [SerializeField] private int[] peg1 = { 1, 2, 3, 4 };
    [SerializeField] private int[] peg2 = { 0, 0, 0, 0 };
    [SerializeField] private int[] peg3 = { 0, 0, 0, 0 };

    [SerializeField] private int currentPeg = 1;

    [ContextMenu("Move Right")]
    public void MoveRight()
    {
        if (CanMoveRight() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg + 1);
        int toIndex = GetIndexOfFreeSlot(toArray);

        if (toIndex == -1) return;

        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        MoveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg + 1);
        disc.SetParent(toPeg);

        TryWinGame();
    }

    [ContextMenu("Move Left")]
    public void MoveLeft()
    {
        if (CanMoveLeft() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg - 1);
        int toIndex = GetIndexOfFreeSlot(toArray);

        if (toIndex == -1) return;

        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        MoveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg - 1);
        disc.SetParent(toPeg);

        TryWinGame();
    }
    public void IncrementPegNumber()
    {
        TurnOffPegIndicator();
        currentPeg++;
        TurnOnPegIndicator();
    }

    public void DecrementPegNumber()
    {
        TurnOffPegIndicator();
        currentPeg--;
        TurnOnPegIndicator();
    }

    Transform PopDiscFromCurrentPeg()
    {
        Transform currentPegTransform = GetPegTransform(currentPeg);
        int index = currentPegTransform.childCount - 1;
        Transform disk = currentPegTransform.GetChild(index);
        return disk;
    }
    Transform GetPegTransform(int pegNumber)
    {
        // Alt way to find peg
        // GameObject pegObject = GameObject.Find("Peg-" + pegNumber.ToString());
        // return pegObject.transform;

        // Can also set up everything ourselves
        if (pegNumber == 1) return peg1Transform;

        if (pegNumber == 2) return peg2Transform;

        return peg3Transform;
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

    bool CanAddToPeg(int value, int[] peg)
    {
        int topNumberIndex = GetTopNumberIndex(peg);
        if (topNumberIndex == -1) return true;

        int topNumber = peg[topNumberIndex];
        return topNumber > value;
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

    int GetIndexOfFreeSlot(int[] peg)
    {
        for (int i = peg.Length - 1; i >= 0; i--)
        {
            if (peg[i] == 0) return i;
        }

        return -1;
    }
    bool IsPegFull(int[] peg)
    {
        for (int i = 0; i < peg.Length; i++)
        {
            if (GetTopNumberIndex(peg) == 0) return true;
        }

        return false;
    }
    void TurnOnPegIndicator()
    {
        if (currentPeg == 1)
        {
            pegIndicator1.SetActive(true);
        }
        else if (currentPeg == 2)
        {
            pegIndicator2.SetActive(true);
        }
        else
        {
            pegIndicator3.SetActive(true);
        }
    }
    void TurnOffPegIndicator()
    {
        if (currentPeg == 1)
        {
            pegIndicator1.SetActive(false);
        }
        else if (currentPeg == 2)
        {
            pegIndicator2.SetActive(false);
        }
        else
        {
            pegIndicator3.SetActive(false);
        }
    }
    void TryWinGame()
    {
        if (IsPegFull(peg3) == true)
        {
            winLabel.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
