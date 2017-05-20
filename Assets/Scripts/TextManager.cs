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

		TextItem TextContainer = JsonUtility.FromJson<TextItem>(text);
        this.TextElement.StartDisplayText(TextContainer);
    }

    public void ClickEvent(){
        if(this.TextElement.activeText == null){
            this.play(TextToPlay.StoryStart);
        }else{
            this.TextElement.ButtonClick();    
        }
    }

	public string getFileContent(string Path)
	{
		string text = System.IO.File.ReadAllText(@Path);
        return text;
    }

}