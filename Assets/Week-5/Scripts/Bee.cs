using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

namespace NotTheBees
{
    public class Bee : MonoBehaviour
    {
        private Hive homeHive;

        public void Init(Hive hive)
        {
            homeHive = hive;
        }
        // Start is called before the first frame update
        void Start()
        {
            CheckAnyFlower();
        }
        private Flower GetRandomFlower()
        {
            Flower[] flowers = FindObjectsByType<Flower>(FindObjectsSortMode.None);
            int randomIndex = Random.Range(0, flowers.Length);
            return flowers[randomIndex];

        }
        private Hive GetHomeHive()
        {
            Hive[] hives = FindObjectsByType<Hive>(FindObjectsSortMode.None);
            int hiveIndex = Random.Range(0, hives.Length);
            return hives[hiveIndex];
        }
        public void CheckAnyFlower()
        {
            Flower foundFlower = GetRandomFlower();
            Hive homeHive = GetHomeHive();

            transform.DOMove(foundFlower.transform.position, 2f).OnComplete(() =>
            {
                if (foundFlower.CanTakeNectar() == false)
                {
                    CheckAnyFlower();
                }
                else
                {
                    foundFlower.TakeNectar();
                    transform.DOMove(homeHive.transform.position, 2f).OnComplete(() =>
                    {
                        homeHive.GiveNectar();
                        CheckAnyFlower();
                    }).SetEase(Ease.Linear);
                }
            }).SetEase(Ease.Linear);
        }
    }
}
