using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace NotTheBees
{
    public class Flower : MonoBehaviour
    {
        public float NectarProductionTimer = 5f;
        private float CurrentTime = 0f;
        bool HasNectar = false;

        // Update is called once per frame
        void Update()
        {
            if (HasNectar == false)
            {
                GetComponent<SpriteRenderer>().color = Color.gray;
                Timer();
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                HasNectar = true;
            }
        }
        void Timer()
        {
            CurrentTime += Time.deltaTime;

            if (CurrentTime == NectarProductionTimer)
            {
                HasNectar = true;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        public bool CanTakeNectar()
        {
            if (HasNectar == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeNectar()
        {
            HasNectar = false;
            CurrentTime = 0f;
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
