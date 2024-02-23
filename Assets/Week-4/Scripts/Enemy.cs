using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo
{
    public class Enemy : MonoBehaviour
    {
        public float health = 10;

        [SerializeField] private Player target;

        public void Damage(float amt)
        {
            health -= amt;
        }

        [ContextMenu("Attack")]
        void Attack()
        {
            target.Damage(3);
        }
    }
}
