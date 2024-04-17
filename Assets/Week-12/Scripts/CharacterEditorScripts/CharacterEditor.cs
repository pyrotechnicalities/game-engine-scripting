using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Switch;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CharacterEditor
{
    public class CharacterEditor : MonoBehaviour
    {
        [SerializeField] Button nextMaterial;
        [SerializeField] Button nextBodyPart;
        [SerializeField] Button loadGame;

        [SerializeField] Character character;

        int id;
        BodyTypes bodyType = BodyTypes.Head;

        private void Awake()
        {
            Button nextMatButton = nextMaterial.GetComponent<Button>();
            nextMatButton.onClick.AddListener(NextMaterial);

            Button nextBodyPtButton = nextBodyPart.GetComponent<Button>();
            nextBodyPtButton.onClick.AddListener(NextBodyPart);

            Button startGame = loadGame.GetComponent<Button>();
            startGame.onClick.AddListener(LoadGame);
        }

        void NextMaterial()
        {
            id++;
            if (id > 3)
            {
                id = 0;
            }

            switch (bodyType)
            {
                case BodyTypes.Head: PlayerPrefs.SetInt("HeadID", id);
                    break;
                case BodyTypes.Body: PlayerPrefs.SetInt("BodyID", id);
                    break;
                case BodyTypes.Arm: PlayerPrefs.SetInt("ArmID", id);
                    break;
                case BodyTypes.Leg: PlayerPrefs.SetInt("LegID", id);
                    break;
                default: PlayerPrefs.SetInt("HeadID", id);
                    break;
            }
            
            character.Load();
            //TODO: Make a switch case for each BodyType and save the value of id to the correct PlayerPref
        }

        void NextBodyPart()
        {
            //TODO: Setup a switch case that will go through the different body types
            //      ie if the current type is Head and we click next then set it to Body
            switch (bodyType)
            {
                case BodyTypes.Head: bodyType = BodyTypes.Body;
                    break;
                case BodyTypes.Body: bodyType = BodyTypes.Arm;
                    break;
                case BodyTypes.Arm: bodyType = BodyTypes.Leg;
                    break;
                case BodyTypes.Leg: bodyType = BodyTypes.Head;
                    break;
                default: bodyType = BodyTypes.Head;
                    break;
            }

            switch (bodyType)
            {
                case BodyTypes.Head: PlayerPrefs.SetInt("HeadID", id);
                    break;
                case BodyTypes.Body: PlayerPrefs.SetInt("BodyID", id);
                    break;
                case BodyTypes.Arm: PlayerPrefs.SetInt("ArmID", id);
                    break;
                case BodyTypes.Leg: PlayerPrefs.SetInt("LegID", id);
                    break;
                default: PlayerPrefs.SetInt("HeadID", id);
                    break;
            }
            //TODO: Then setup another switch case that will get the current saved value
            //      from the player prefs for the current body type and set it to id
        }

        void LoadGame()
        {
            SceneManager.LoadScene("CharacterCreatorGame");
        }
    }
}