using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI label;

    // get words working with button (pass in data type string)
    public void PrintMessage(string message)
    {
        label.text = message;
    }

    // add numbers together and print the result with the button (pass in data type int)
    public void Add(int number)
    {
        label.text = (number + 10).ToString();
    }
}
