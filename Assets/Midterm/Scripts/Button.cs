using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midterm
{
    public class Button : MonoBehaviour
    {
        [SerializeField] GameObject questionDisplay;
        [SerializeField] GameObject answerInput;
        [SerializeField] private AnswerCheck answerCheck;
        public int currentButton = 0;
        public int buttonValue;

        public void ShowAnswerInputScreen(int button)
        {
            currentButton = button;
            answerInput.SetActive(true);
            questionDisplay.SetActive(false);
            answerCheck.DisplayQuestion(currentButton);
        }
        public void BackToQuestionDisplay()
        {
            answerCheck.ClearInputField();
            answerInput.SetActive(false);
            questionDisplay.SetActive(true);
        }
        public void Points(int button)
        {
            currentButton = button;
            /*if (currentButton = first in row) buttonValue = 10;
            if (currentButton = second in row) buttonValue = 20;
            if (currentButton = third in row) buttonValue = 30;
            if (currentButton = fourth in row) buttonValue = 40;
            if (currentButton = fifth in row) buttonValue = 50;*/
        }
    }
}
