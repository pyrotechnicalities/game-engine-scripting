using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayDemo : MonoBehaviour
{
    [SerializeField] int[] array = new int[] { 1, 4, 6, 325246, 34 };

    [ContextMenu("Execute")]
    void Execute()
    {
        Debug.Log(array[0]);
        Debug.Log(array[1]);
        Debug.Log(array[2]);
        Debug.Log(array[3]);
    }
}
