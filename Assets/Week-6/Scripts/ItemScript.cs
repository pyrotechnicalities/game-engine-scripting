using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoalScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
