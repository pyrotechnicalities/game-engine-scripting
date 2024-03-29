using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace NotTheBees
{
    public class Hive : MonoBehaviour
    {
        private Hive thisHive;
        public float HoneyProductionTimer = 10f;
        private float CurrentTime = 0f;
        int NectarStash = 0;
        int HoneyStash = 0;
        private Bee[] bees = new Bee[2];
        public GameObject beePrefab;

        // Start is called before the first frame update
        void Start()
        {
            foreach (var bee in bees)
            {
                GameObject newBeeObject = Instantiate(beePrefab);
                Bee newBee = newBeeObject.GetComponent<Bee>();
                newBee.Init(thisHive);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (NectarStash > 1)
            {
                Timer();
            }
        }

        void Timer()
        {
            CurrentTime += Time.deltaTime;

            if (CurrentTime >= HoneyProductionTimer)
            {
                NectarStash--;
                HoneyStash++;
                
                if (NectarStash > 0)
                {
                    CurrentTime = 0f;
                }
            }
        }
        public void GiveNectar()
        {
            NectarStash++;
        }
    }
}
