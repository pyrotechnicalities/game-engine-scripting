using UnityEngine;

namespace CharacterEditor
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Head;
        [SerializeField] private MeshRenderer m_Body;
        [SerializeField] private MeshRenderer m_ArmR;
        [SerializeField] private MeshRenderer m_ArmL;
        [SerializeField] private MeshRenderer m_LegR;
        [SerializeField] private MeshRenderer m_LegL;

        private void Start()
        {
            Load();
        }

        public void Load()
        {
            MaterialManager.Get(BodyTypes.Head, PlayerPrefs.GetInt("HeadID"));
            MaterialManager.Get(BodyTypes.Body, PlayerPrefs.GetInt("BodyID"));
            MaterialManager.Get(BodyTypes.Arm, PlayerPrefs.GetInt("ArmID"));
            MaterialManager.Get(BodyTypes.Leg, PlayerPrefs.GetInt("LegID"));
        }
    }
}