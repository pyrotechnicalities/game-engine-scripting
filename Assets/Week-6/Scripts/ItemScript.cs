using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoalScript : MonoBehaviour
    {
        private void Awake()
        {
            MazeManager.AddGameOverEventListener(OnGameOver);
        }
        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
        }
        void OnGameOver()
        {
            gameObject.SetActive(true);
            if(gameObject.tag == "Goal") { gameObject.SetActive(false); }
        }
        public void ResetGoalItem()
        {
            if (gameObject.tag == "Goal") { gameObject.SetActive(true); }
        }
    }
}
