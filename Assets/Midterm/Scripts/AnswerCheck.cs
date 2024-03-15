using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Midterm
{
    public class AnswerCheck : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI question;
        [SerializeField] TextMeshProUGUI result;
        [SerializeField] TextMeshProUGUI scoreLabel;
        private int score;

        // stores questions, first five elements are category one, next five are category 2, and so on
        string[] questions = new string[]
        {
            "cat1q1",
            "cat1q2",
            "cat1q3",
            "cat1q4",
            "cat1q5",
            "cat2q1",
            "cat2q2",
            "cat2q3",
            "cat2q4",
            "cat2q5",
            "cat3q1",
            "cat3q2",
            "cat3q3",
            "cat3q4",
            "cat3q5",
            "cat4q1",
            "cat4q2",
            "cat4q3",
            "cat4q4",
            "cat4q5",
            "cat5q1",
            "cat5q2",
            "cat5q3",
            "cat5q4",
            "cat5q5",
            "cat6q1",
            "cat6q2",
            "cat6q3",
            "cat6q4",
            "cat6q5"
        };
        string[] answers = new string[]
        {
            "cat1a1",
            "cat1a2",
            "cat1a3",
            "cat1a4",
            "cat1a5",
            "cat2a1",
            "cat2a2",
            "cat2a3",
            "cat2a4",
            "cat2a5",
            "cat3a1",
            "cat3a2",
            "cat3a3",
            "cat3a4",
            "cat3a5",
            "cat4a1",
            "cat4a2",
            "cat4a3",
            "cat4a4",
            "cat4a5",
            "cat5a1",
            "cat5a2",
            "cat5a3",
            "cat5a4",
            "cat5a5",
            "cat6a1",
            "cat6a2",
            "cat6a3",
            "cat6a4",
            "cat6a5"
        };

        public void CheckAnswer(int button)
        {
            question.text = questions[button];

            InputField field = GameObject.Find("InputAnswer").GetComponent<InputField>();
            string userInput = field.text;

            if (userInput.ToUpper() == answers[button].ToUpper())
            {
                IncrementScore(button);
            }
            else
            {
                DecrementScore(button);
            }
        }
        public void IncrementScore(int button)
        {
            // score plus value of button 
            score = score + button;
        }
        public void DecrementScore(int button)
        {
            // score minus value of button
            score = score - button;
        }
        public void ChangeScoreLabel()
        {
            scoreLabel.text = string.Format("Score: {0}", score);
        }

        // CURRENT ISSUES:
        // -Get input field to work
        // -Fix increment and decrement score (have them add or subtract the correct values associated with the button that was pressed)
        // -Turn off buttons that have been pressed
        // -When button is pressed, pass a value in that corresponds to the right index value
        // Add questions and answers
    }
}
