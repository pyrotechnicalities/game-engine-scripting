using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] Transform m_DoorTransform;
        [SerializeField] Vector3 m_PositionOpenOffset;

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
            Open();
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log("Door trigger is still being triggered");
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Something has left the trigger");
            m_DoorTransform.position = m_PositionClose;
            m_IsOpening = false;
        }
        public void Open()
        {
            m_IsOpening = true;
        }
    }
}
