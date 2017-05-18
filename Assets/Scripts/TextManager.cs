using System;
using UnityEngine;


public enum TextToPlay { StoryStart, StoryWon, StoryLost, TutorialAtStart, TutorialCamp, TutorialShipyard };

public class TextManager : MonoBehaviour
{
    public TextItem activeTextPassage;
    public TextElement TextElement;

    public void play(TextToPlay texttype){
        string text = "";

        switch(texttype){

            case TextToPlay.StoryStart:
                text = getFileContent("Assets/Scripts/Text/storyStart.json");
            break;
        }

		TextItem TextContainer = JsonUtility.FromJson<TextItem>(text);
        this.TextElement.StartDisplayText(TextContainer);
    }

    public void ClickEvent(){
        this.play(TextToPlay.StoryStart);
    }

	public string getFileContent(string Path)
	{
		string text = System.IO.File.ReadAllText(@Path);
        return text;
    }






}