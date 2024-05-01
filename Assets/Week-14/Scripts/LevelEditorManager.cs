using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace LevelCreator
{
    public class LevelEditorManager : MonoBehaviour
    {
        private string lvlNumberText = " ";
        private int lvlNumber;
        private string lvlName = " ";
        private string lvlRewardText = " ";
        private int lvlReward;
        private string lvlEnemyCountText = " ";
        private int lvlEnemyCount;
        public LevelEditorData data;

        [SerializeField] TMP_InputField LevelNumberInput;
        [SerializeField] TMP_InputField LevelNameInput;
        [SerializeField] TMP_InputField LevelRewardInput;
        [SerializeField] TMP_InputField LevelEnemiesInput;
        [SerializeField] GameObject ErrorMessage;

        public string GetLvlNumber(string userInput)
        {
            bool result = int.TryParse(LevelNumberInput.text, out lvlNumber);
            if (result == false)
            {
                ErrorMessage.SetActive(true);
                LevelNumberInput.text = "";
            }
            else
            {
                lvlNumberText = lvlNumber.ToString("D2");
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
            bool result = int.TryParse(LevelRewardInput.text, out lvlReward);
            if (result == false)
            {
                ErrorMessage.SetActive(true);
                LevelRewardInput.text = "";
            }
            else
            {
                lvlRewardText = lvlReward.ToString();
            }
            return lvlRewardText;
        }
        public string GetLvlEnemyCount(string userInput)
        {
            bool result = int.TryParse(LevelEnemiesInput.text, out lvlEnemyCount);
            if (result == false)
            {
                ErrorMessage.SetActive(true);
                LevelEnemiesInput.text = "";
            }
            else
            {
                lvlEnemyCountText = lvlEnemyCount.ToString();
            }
            return lvlEnemyCountText;
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
            lvlRewardText = GetLvlReward(userInput);
            Debug.Log(lvlRewardText);
        }
        public void StoreLvlEnemies(string userInput)
        {
            lvlEnemyCountText = GetLvlEnemyCount(userInput);
            Debug.Log(lvlEnemyCountText);
        }
        public void OnSave()
        {
            string path = $"Assets/Resources/Levels/Level_{lvlNumberText}.txt";
            StreamWriter writer = new StreamWriter(path, false);

            data.lvlNumber = lvlNumberText;
            data.lvlName = lvlName;
            data.lvlReward = lvlRewardText;
            data.lvlEnemyCount = lvlEnemyCountText;

            string json = JsonUtility.ToJson(data);
            writer.WriteLine(json);
            writer.Close();

            AssetDatabase.ImportAsset(path);
        }
        public void ClearError()
        {
            ErrorMessage.SetActive(false);
        }
    }
}
