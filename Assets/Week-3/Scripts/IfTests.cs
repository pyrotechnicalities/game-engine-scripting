using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfTests : MonoBehaviour
{
    [SerializeField] int number = 22435;
    [SerializeField] string word = "Bird";

    [ContextMenu("Execute")]
    void ExecuteTest()
    {

        int starsEarned = 3;

        // inline if statement
        // ? is the if, : shows what happens if condition is met then if it is not met
        int coinsEarned = starsEarned <= 2 ? (starsEarned == 2 ? 250 : 100) : 500;


        // these if statements are equivalent to the inline if statement above
        if (starsEarned == 3)
        {
            coinsEarned = 500;
        }
        else if (starsEarned == 2)
        {
            coinsEarned = 250;
        }
        else
        {
            coinsEarned = 100;
        }


        Debug.Log("Test Executed");

        if (number == 22435 && word == "Bird")
        {
            Debug.Log(word);
        }
        
        if (number != 22435 || word == "Dog")
        {
            Debug.Log("Not Equals");
        }
    }
}
