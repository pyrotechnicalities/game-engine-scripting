using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace LevelCreator
{
    public class LevelEditorManager : MonoBehaviour
    {
        // TODO:
        // - add ints for reward and enemy count similar to level number
        // - label thing as described in getlvlnumber
        // - save to JSON
        private string lvlNumberText = " ";
        private int LvlNumber;
        private string lvlName = " ";
        private string lvlReward = " ";
        private string lvlEnemyCount = " ";
        public LevelEditorData data;

        [SerializeField] TMP_InputField LevelNumberInput;
        [SerializeField] TMP_InputField LevelNameInput;
        [SerializeField] TMP_InputField LevelRewardInput;
        [SerializeField] TMP_InputField LevelEnemiesInput;

        public string GetLvlNumber(string userInput)
        {
            bool result = int.TryParse(LevelNumberInput.text, out LvlNumber);
            if (result == false)
            {
                // turn on label that says "please enter a number" 
                // then clear input field
            }
            else
            {
                lvlNumberText = LvlNumber.ToString("D2");
            }
            return lvlNumberText;
        }
        public string GetLvlName(string userInput)
        {
            lvlName = LevelNameInput.text;
            return lvlName;
        }
        public string GetLvlReward(string userInput)
        {
            lvlReward = LevelRewardInput.text;
            return lvlReward;
        }
        public string GetLvlEnemyCount(string userInput)
        {
            lvlEnemyCount = LevelEnemiesInput.text;
            return lvlEnemyCount;
        }
        public void StoreLvlNumber(string userInput)
        {
            lvlNumberText = GetLvlNumber(userInput);
            Debug.Log(lvlNumberText);
        }
        public void StoreLvlName(string userInput)
        {
            lvlName = GetLvlName(userInput);
            Debug.Log(lvlName);
        }
        public void StoreLvlReward(string userInput)
        {
            lvlReward = GetLvlReward(userInput);
            Debug.Log(lvlReward);
        }
        public void StoreLvlEnemies(string userInput)
        {
            lvlEnemyCount = GetLvlEnemyCount(userInput);
            Debug.Log(lvlEnemyCount);
        }
        public void OnSave()
        {
            string path = "Assets/Resources/Levels/Level_LevelNumber.txt";
            StreamWriter writer = new StreamWriter(path, false);
        }
    }
}
