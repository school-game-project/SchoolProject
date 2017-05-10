using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Nature;

public class GameController : MonoBehaviour
{
    public DayNightController dayNightController;

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
