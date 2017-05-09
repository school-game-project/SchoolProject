using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nature
{
    public class DayNightController : MonoBehaviour
    {
        public int hours = 0;
        public int minutes = 0;

        private Light light;

        private void Start()
        {
            light = GetComponent<Light>();
            
        }

        private void Update()
        {
            transform.eulerAngles = new Vector3(-60 + (hours * 11.5f) + (minutes * 0.1916f) , 0, 0);

            //light.color = new Color(1, Mathf.Clamp(timeController.time.Hour / 11f, 0, 1), Mathf.Clamp(timeController.time.Hour / 14f, 0, 1));

        }

    }
}
