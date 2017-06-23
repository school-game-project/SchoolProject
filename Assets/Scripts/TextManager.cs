using System;
using UnityEngine;


public enum TextToPlay { StoryStart, StoryWon, StoryLost, TutorialAtStart, TutorialCamp, TutorialShipyard };

public class TextManager : MonoBehaviour
{
    public TextItem activeTextPassage;
    public TextElement TextElement;
    public GameController gc;
    private GameObject TextTopLeft;

    public void Start()
    {
        gc.OnGameStart += StoryStartEventListner;
        gc.OnGameEnd += StoryLostEventListner;
        gc.OnGameWin += StoryWonEventListner;

		this.TextTopLeft = this.gameObject.transform.GetChild(0).gameObject;

	}

    public GameObject GetTextBox(){
        return this.TextTopLeft;
    }

    // Story Start Event Handler
    public void StoryStartEventListner() {
        this.play(TextToPlay.StoryStart);
	}

	// Story Won Event Handler
	public void StoryWonEventListner()
	{
        this.play(TextToPlay.StoryWon);
	}

	// Story Lost Event Handler
	public void StoryLostEventListner()
	{
        this.play(TextToPlay.StoryLost);
	}

	// Story TutorialAtStart Event Handler
	public void TutorialAtStartEventListner()
	{
		this.play(TextToPlay.TutorialAtStart);
	}

	// Story TutorialCampEventListner Event Handler
	public void TutorialCampEventListner()
	{
		this.play(TextToPlay.TutorialCamp);
	}

	// Story TutorialShipyardEventListner Event Handler
	public void TutorialShipyardEventListner()
	{
		this.play(TextToPlay.TutorialShipyard);
	}


    private void play(TextToPlay texttype) {
        string text = "";

        switch(texttype){

            case TextToPlay.StoryStart:
                text = getFileContent("Assets/Scripts/Text/StoryStart.json");
            break;

            case TextToPlay.StoryWon:
                text = getFileContent("Assets/Scripts/Text/StoryWon.json");
            break;

            case TextToPlay.StoryLost:
                text = getFileContent("Assets/Scripts/Text/StoryLost.json");
            break;
                
            case TextToPlay.TutorialAtStart:
                text = getFileContent("Assets/Scripts/Text/TutorialAtStart.json");
            break;

            case TextToPlay.TutorialCamp:
                text = getFileContent("Assets/Scripts/Text/TutorialCamp.json");
            break;

            case TextToPlay.TutorialShipyard:
                text = getFileContent("Assets/Scripts/Text/TutorialShipyard.json");
            break;

        }

        // Load Text from JSON File
		TextItem TextContainer = JsonUtility.FromJson<TextItem>(text);

        this.TextElement.StartDisplayText(this, TextContainer);
    }



    public void ClickEvent(){
        this.TextElement.ButtonClick();    
    }

	public string getFileContent(string Path)
	{
		string text = System.IO.File.ReadAllText(@Path);
        return text;
    }

}