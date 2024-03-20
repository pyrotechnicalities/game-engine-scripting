using System;
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
        [SerializeField] TMP_InputField inputAnswer;
        [SerializeField] GameObject resultLabel;
        [SerializeField] Button pressedButton;
        private int score;
        private string input = " ";

        // stores questions, first five elements are category one, next five are category 2, and so on
        string[] questions = new string[]
        {
            "What video game series is used as the \"Face of Nintendo\"?",
            "Which version of The Sims is free to play on Steam?",
            "How many entries are there in the Persona series, not counting spinoffs?",
            "How many times was Breath of the Wild delayed before its release in 2017?",
            "Where does the theme music for Tetris come from?",
            "What real-world event does Suzanne Collins cite as an influnce on The Hunger Games?",
            "What city does the Divergent series take place in?",
            "What series is Kaz Brekker one of the protagonists of?",
            "How many books currently make up the Riordanverse?",
            "What's the name of the contemporary fantasy series set in a fictional town in Virginia?",
            "Who is the author of Fullmetal Alchemist?",
            "Which artist sang the first opening of Jujutsu Kaisen?",
            "What year did Naruto end?",
            "What animation style does Trigun: Stampede use?",
            "What was the first anime movie to win an Oscar?",
            "Calico cats are typically what sex?",
            "What does a cat use for balance?",
            "What is the name of the phobia of cats?",
            "What is a group of cats called?",
            "How many muscles does a cat have in its ear?",
            "Which line is the busiest?",
            "Which line is the only one to not go all the way to the Loop?",
            "When did the CTA take over duties of running the L?",
            "How many different kinds of trains are currently operating through the whole CTA system?",
            "What stop is the only one in the Loop that has been restored to its original appearance?",
            "What's the name of the track that plays while Anakin and Obi-Wan duel on Mustafar in Episode III?",
            "What is the Mandalorian's true name?",
            "Who typically wields a blue lightsaber?",
            "What planet was Jyn Erso imprisoned on in the beginning of Rogue One?",
            "What is the more common name of Form IV?"
        };
        string[] answers = new string[]
        {
            "super mario",
            "the sims 4",
            "six",
            "twice",
            "a russian folk song",
            "the iraq war",
            "chicago",
            "six of crows",
            "twenty two",
            "the raven cycle",
            "hiromu arakawa",
            "eve",
            "2014",
            "3dcg",
            "spirited away",
            "female",
            "the tail",
            "ailurophobia",
            "a clowder",
            "thirty two",
            "the red line",
            "the yellow line",
            "1947",
            "four",
            "quincy",
            "duel of the fates",
            "din djarin",
            "jedi guardians",
            "wobani",
            "ataru"
        };
        public string GetAnswer(string userInput)
        {
            input = inputAnswer.text;
            return input;
        }
        public void CheckAnswer(string userInput)
        {
            input = GetAnswer(userInput).ToLower();
            if (input == answers[pressedButton.currentButton])
            {
                ShowResultLabel();
                result.text = $"You were correct! You gain {pressedButton.buttonValue} points.";
                IncrementScore();
                ChangeScoreLabel();
            }
            else
            {
                ShowResultLabel();
                result.text = $"You were incorrect. You lose {pressedButton.buttonValue} points.";
                DecrementScore();
                ChangeScoreLabel();
            }
        }
        public void DisplayQuestion(int button)
        {
            pressedButton.currentButton = button;
            question.text = questions[pressedButton.currentButton];
        }
        public void IncrementScore()
        {
            // score plus value of button 
            score = score + pressedButton.buttonValue;
        }
        public void DecrementScore()
        {
            // score minus value of button
            score = score - pressedButton.buttonValue;
        }
        private void ChangeScoreLabel()
        {
            scoreLabel.text = string.Format("Score: {0}", score);
        }
        private void ShowResultLabel()
        {
            resultLabel.SetActive(true);
        }
        public void ClearInputField()
        {
            resultLabel.SetActive(false);
            input = "";
            inputAnswer.text = "";
        }
    }
}
