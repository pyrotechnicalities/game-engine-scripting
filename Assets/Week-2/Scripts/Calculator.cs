using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Windows;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI label;
    public float prevInput;
    public bool clearPrevInput = true;

    private EquationType equationType;

    private void Start()
    {
        Clear();
    }

    public void AddInput(string input)
    {
        if (clearPrevInput == true)
        {
            label.text = string.Empty;
            clearPrevInput = false;
        }


        //TODO: Add the input passed into the AddInput function to the current value of the label
        //      Hint. You can perform the + operations on string data to combine them
    }

    public void SetEquationAsAdd()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }

    public void SetEquationAsSubtract()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.SUBTRACT;
    }

    public void SetEquationAsMultiply()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.MULTIPLY;
    }

    public void SetEquationAsDivide()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.DIVIDE;
    }

    private void Add(int input)
    {
        label.text = (input + prevInput).ToString();
    }

    private void Subtract(int input)
    {
        label.text = (input - prevInput).ToString();
    }

    private void Multiply(int input)
    {
        label.text = (input * prevInput).ToString();
    }

    private void Divide(int input)
    {
        label.text = (input / prevInput).ToString();
    }

    public void Clear()
    {
        //TODO: Reset the state of your calculator... reset the display value to a 0
        clearPrevInput = true;
        prevInput = 0;
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
      //  if (equationType == EquationType.ADD) Add();
     //   else if (equationType == EquationType.SUBTRACT) Subtract();
     //   else if (equationType == EquationType.MULTIPLY) Multiply();
     //   else if (equationType == EquationType.DIVIDE) Divide();
    }

    public enum EquationType
    {
        None = 0,
        ADD = 1,
        SUBTRACT = 2,
        MULTIPLY = 3,
        DIVIDE = 4
    }
}
