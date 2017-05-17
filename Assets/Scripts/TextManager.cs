using System;
using UnityEngine;


public enum TextToPlay {StoryStart, StoryWon, StoryLost, TutorialAtStart, TutorialCamp, TutorialShipyard}

public class TextManager : MonoBehaviour
{
    public TextItem activeTextPassage;

    private StoryStart storyStartDataClass;

	void Start()
	{

        storyStartDataClass = new StoryStart();

        /*
		LES MICH!

            Wenn du Monobehaviour vererbst dann kannst du das nicht mit New initiliesieren
            das musst du dann an ein GameObject(beispiel dein Text) damit es sozusagen ein Objekt wird
            

            versuch mal erstmal nicht diese kranke vererbung
            mach es einfach mal richtig basic
        */

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