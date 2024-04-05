using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("How much damage the player can take")]
        [Range(0f, 100f)]
        private float health = 10;

        [SerializeField] GameObject player;

        [SerializeField]
        [TextArea(1,5)]
        private string Name;

        public void Damage(float amt)
        {
            health -= amt;
        }

        private Enemy FindNewTarget()
        {
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            int randomIndex = Random.Range(0, enemies.Length);
            return enemies[randomIndex];
        }
        [ContextMenu("Attack")]
        void Attack()
        {
            Enemy target = FindNewTarget();
            // how to get movement working with DOTween
            Vector3 origin = transform.position;

            transform.DOMove(target.transform.position, 1f)
                    .OnComplete(() =>
                    {
                        target.Damage(10);
                        // what happens when we get there

                        // go back
                        transform.DOMove(origin, 1f);
                    });

            // play sound
        }
        void OnGameOver()
        {
            player.SetActive(false);
        }
        private void Start()
        {
            GameManager.AddGameOverEventListener(OnGameOver);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // play sound on space
            }
        }
    }
}
