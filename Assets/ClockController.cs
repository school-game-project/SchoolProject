﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Nature;

public class ClockController : MonoBehaviour {

    public DayNightController dayNightController;

    public Text hoursText;
    public Text minText;

	// Use this for initialization
	void Start ()
    {
        //dayNightController.GetActualTime += SetTime;
	}
	
	private void SetTime(int hours, int min)
    {
        hoursText.text = hours.ToString("00");
        minText.text = min.ToString("00");
    }
}
