using System;
using UnityEngine;


public enum TextToPlay {StoryStart, StoryWon, StoryLost, TutorialAtStart, TutorialCamp, TutorialShipyard}

public class TextManager : MonoBehaviour
{
    private TextItem activeTextPassage;


	void Start()
	{
		this.activeTextPassage = new StoryStart();
	}

    public void play(TextToPlay texttype){

        switch (texttype) {

            case TextToPlay.StoryStart:
                
            break;

            case TextToPlay.StoryWon:
                
            break;


			case TextToPlay.StoryLost:

			break;


			case TextToPlay.TutorialAtStart:

			break;


			case TextToPlay.TutorialCamp:

			break;

            case TextToPlay.TutorialShipyard:
                
            break;

        }
    }

    public void ClickEvent(){
        this.activeTextPassage.StartDisplay();
    }


}