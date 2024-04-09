using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Maze
{
    public class MazeManager : MonoBehaviour
    {
        private static UnityEvent GameOverEvent = new UnityEvent();

        public void GameOver()
        {
            GameOverEvent.Invoke();
        }

        public static void AddGameOverEventListener(UnityAction action)
        {
            GameOverEvent.AddListener(action);
        }
    }
}
