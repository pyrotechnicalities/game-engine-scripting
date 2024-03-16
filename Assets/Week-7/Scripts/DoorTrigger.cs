using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] Transform m_DoorTransform;
        [SerializeField] Vector3 m_PositionOpenOffset;
        [SerializeField] Week6Demo player;

        private Vector3 m_PositionClose;
        private Vector3 m_PositionOpen;

        bool m_IsOpening;
        float m_Alpha;

        private void Awake()
        {
            m_PositionClose = m_DoorTransform.position;
            m_PositionOpen = m_PositionOpenOffset + m_PositionClose;
        }
        private void Update()
        {
            if (m_IsOpening == true) m_Alpha += Time.deltaTime;
            else m_Alpha -= Time.deltaTime;
            m_Alpha = Mathf.Clamp(m_Alpha, 0, 1);

            m_DoorTransform.position = Vector3.Lerp(m_PositionClose, m_PositionOpen, m_Alpha);
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Door trigger has been triggered");
            // m_DoorTransform.position = m_PositionOpen + m_PositionClose;
            if(player.hasKeys == true)
            {
                Open();
            }
            else
            {
                player.OpenDoor();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log("Door trigger is still being triggered");
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Something has left the trigger");
            player.LeaveDoor();
            m_DoorTransform.position = m_PositionClose;
            m_IsOpening = false;
        }
        public void Open()
        {
            player.numKeys = player.numKeys - 1;
            player.keysLabel.text = string.Format("Keys: {0}", player.numKeys);
            if (player.numKeys == 0) { player.hasKeys = false; }
            m_IsOpening = true;
        }
    }
}
