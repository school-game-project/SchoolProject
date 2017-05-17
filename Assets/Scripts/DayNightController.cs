using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nature
{
    public class DayNightController : MonoBehaviour
    {
        public float timeScale;
        public int hours = 0;
        public int minutes = 0;

        public delegate void OnNextTime(int hours, int min);
        public event OnNextTime GetActualTime; 

        private Light light;

        private void Start()
        {
            light = GetComponent<Light>();

            GetActualTime += SetSunFlare;
            
        }

        public void StartTime(string json)
        {
            this.hours = int.Parse(json.Split(':')[0]);
            this.minutes = int.Parse(json.Split(':')[1]);
            StartCoroutine(NextTime());
        }

        private void SetSunFlare(int hours, int min)
        {
            if(hours > 18 || hours < 6)
            {
                this.GetComponent<Light>().intensity -= 0.01f;
            }
            else
            {
                if (this.GetComponent<Light>().intensity < 1.0f)
                    this.GetComponent<Light>().intensity += 0.01f;
            }

            transform.eulerAngles = new Vector3(-60 + (hours * 11.5f) + (min * 0.1916f), 0, 0);
        }

        IEnumerator NextTime()
        {
            while (true)
            {
                minutes += 1;
                if (hours >= 24)
                    hours = 0;

                if (minutes >= 60)
                {
                    minutes = 0;
                    hours += 1;
                }         

                GetActualTime(hours, minutes);

                yield return new WaitForSeconds(timeScale / 10);
            }
 
        }

    }
}
