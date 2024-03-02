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
        public Hive hive;
        public Flower flower;

        public void Init(Hive hive)
        {
            hive = homeHive;
        }
        public void CheckAnyFlower()
        {
            FindObjectsByType<Flower> (FindObjectsSortMode.None);
            transform.DOMove(flower.transform.position, 1f).OnComplete(() =>
            {
                flower.CanTakeNectar();
                if (flower.CanTakeNectar() == true)
                {
                    flower.TakeNectar();
                    ReturnToHive();
                }
                else
                {
                    CheckAnyFlower();
                }


            }).SetEase(Ease.Linear);
        }
        public void ReturnToHive()
        {
            FindObjectsByType<Hive>(FindObjectsSortMode.None);
            transform.DOMove(homeHive.transform.position, 1f).OnComplete(() =>
            {
                hive.GiveNectar();
            }).SetEase(Ease.Linear);
            CheckAnyFlower();
        }
    }
}
