using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Nature;

public class GameController : MonoBehaviour
{
    public DayNightController dayNightController;
    public CountDownController countdownController;
    public Animator MenuAnimations;
    public GameObject Menu;
    public InventoryUI InventoryClone;
    public GameObject Interface;

    private string mapJSON;
    private string timeJSON;

    private void Start()
    {
        dayNightController.GetActualTime += SetTimeJson;
        LoadData();
        
        dayNightController.StartTime(timeJSON);

        Instantiate(Interface);
        

        countdownController = GameObject.FindWithTag("CountDown").GetComponent<CountDownController>();
        countdownController.StartCountDown();
        countdownController.OnCountdownOver += OnCountDownDone;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            this.InventoryClone.SetShowingThis();
    }

    private void OnApplicationQuit()
    {
        SaveData();
        PlayerPrefs.Save();
    }

    private void OnCountDownDone(bool won)
    {

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
        Menu.SetActive(true);

        MenuAnimations.Play("Menu_Show");

        StartCoroutine(FreezeGame(0.2f));
    }

    public void HideMenu()
    {
        Time.timeScale = 1.0f;

        MenuAnimations.Play("Menu_Hide");

        Menu.SetActive(false);
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
