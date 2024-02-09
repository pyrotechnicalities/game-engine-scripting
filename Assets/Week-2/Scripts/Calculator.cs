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

        label.text = string.Empty + input;
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
        label.text = (input % prevInput).ToString();
    }

    public void Clear()
    {
        label.text = string.Empty;
        clearPrevInput = true;
        prevInput = 0;
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
        if (equationType == EquationType.ADD) Add(1);
        else if (equationType == EquationType.SUBTRACT) Subtract(2);
        else if (equationType == EquationType.MULTIPLY) Multiply(3);
        else if (equationType == EquationType.DIVIDE) Divide(4); 
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
