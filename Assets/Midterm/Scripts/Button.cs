using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midterm
{
    public class Button : MonoBehaviour
    {
        [SerializeField] GameObject questionDisplay;
        [SerializeField] GameObject answerInput;
        public void ShowAnswerInputScreen()
        {
            answerInput.SetActive(true);
            questionDisplay.SetActive(false);
        }
        public void BackToQuestionDisplay()
        {
            answerInput.SetActive(false);
            questionDisplay.SetActive(true);
        }
    }
}
