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

        label.text += input;
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

    private void Add()
    {
        float currentInput = float.Parse(label.text);
        float result = currentInput + prevInput;
        label.text = result.ToString();
    }

    private void Subtract()
    {
        float currentInput = float.Parse(label.text);
        float result = currentInput - prevInput;
        label.text = result.ToString();
    }

    private void Multiply()
    {
        float currentInput = float.Parse(label.text);
        float result = currentInput * prevInput;
        label.text = result.ToString();
    }

    private void Divide()
    {
        float currentInput = float.Parse(label.text);
        float result = currentInput / prevInput;
        label.text = result.ToString();
    }

    public void Clear()
    {
        label.text = "0";
        clearPrevInput = true;
        prevInput = 0;
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
        if (equationType == EquationType.ADD) Add();
        else if (equationType == EquationType.SUBTRACT) Subtract();
        else if (equationType == EquationType.MULTIPLY) Multiply();
        else if (equationType == EquationType.DIVIDE) Divide(); 
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
