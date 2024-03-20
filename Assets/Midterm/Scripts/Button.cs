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
        private UnityEngine.UI.Button thisButton;
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
        public void TurnOff(UnityEngine.UI.Button tempButton)
        {
            thisButton = tempButton;
            thisButton = thisButton.GetComponent<UnityEngine.UI.Button>();
            thisButton.interactable = false;
        }
        public void Points(int button)
        {
            currentButton = button;
            if (currentButton is 0 or 5 or 10 or 15 or 20 or 25) buttonValue = 10;
            if (currentButton is 1 or 6 or 11 or 16 or 21 or 26) buttonValue = 20;
            if (currentButton is 2 or 7 or 12 or 17 or 22 or 27) buttonValue = 30;
            if (currentButton is 3 or 8 or 13 or 18 or 23 or 28) buttonValue = 40;
            if (currentButton is 4 or 9 or 14 or 19 or 24 or 29) buttonValue = 50;
        }
    }
}
