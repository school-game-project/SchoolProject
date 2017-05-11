﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Nature;

public class GameController : MonoBehaviour
{
    public DayNightController dayNightController;
    public Animator MenuAnimations;

    private string mapJSON;
    private string timeJSON;


    private void Start()
    {
        dayNightController.GetActualTime += SetTimeJson;
        LoadData();
        dayNightController.StartTime(timeJSON);
    }

    private void OnApplicationQuit()
    {
        SaveData();
        PlayerPrefs.Save();
    }

    public void SetTimeJson(int hours, int min)
    {
        timeJSON = hours.ToString("00") + ":" + min.ToString("00");
    }
    public void SetMapJSON(string map)
    {
        mapJSON = map;
    }

    public void ShowMenu()
    {
        MenuAnimations.Play("Menu_Show");

        StartCoroutine(FreezeGame(0.2f));
    }

    public void HideMenu()
    {
        Time.timeScale = 1.0f;

        MenuAnimations.Play("Menu_Hide");
    }

    private IEnumerator FreezeGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Time.timeScale = 0.0f;
    }


    private void LoadData()
    {
        mapJSON = PlayerPrefs.GetString("Map", "");
        timeJSON = PlayerPrefs.GetString("Time", "06:00");


    }
    private void SaveData()
    {
        PlayerPrefs.SetString("Map", mapJSON);
        PlayerPrefs.SetString("Time", timeJSON);
    }
	
}