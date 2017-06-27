using System;
using System.Collections.Generic;
using UnityEngine;


public enum TextToPlay { StoryStart, StoryWon, StoryLost, TutorialAtStart, TutorialCamp, TutorialShipyard };

public class TextManager : MonoBehaviour
{
    public TextItem activeTextPassage;
    public TextElement TextElement;
    public GameController gc;
    private GameObject TextTopLeft;
    public Dictionary<TextToPlay, List<string>> textDic = new Dictionary<TextToPlay, List<string>>();

    public void Awake()
    {
        textDic.Add(TextToPlay.StoryLost, new List <string> { "Loser" });
        textDic.Add(TextToPlay.StoryStart, new List<string>  { "Wir waren eine ganze Bande von Orgs und erkundeten die große See und trafen auf eine kleine Insel, die auf keine unserer Karten eingezeichnet war. Wir legten mit unserem Schiff vor der Küste der Insel an und stiegen in kleine Beiboote um die Insel zu erreichen.",
             "Das erste, das wir sahen, als wir ans Ufer stießen war ein riesiger Berg in der Mitte der Insel. Auf ersten Blick schien sie von nichts als kleinen Tieren bewohnt. Wir machten uns sofort an das Erkunden. Ich und ein paar andere Orgs machten sich auf um den berg zu erkunden. Je höher wir stiegen, desto heißer wurde es. Wir stellten fest, das es ein Vulkan war.",
             "Wir wussten, das er bald ausbrechen würde. Wir rannten so schnell wir konnten den Berg hinab. In der panik verlor ich meine Gruppe. Ich hetzte angst erfüllt durch den Wald in richtung strand.",
             "Als ich endlich am Strand angekommen war, sah ich wie meine kammeraden wegsegelte. Ich war allein, auf einer Insel auf der ein Vulkan bald ausbrechen würde. Ich brauchte ein Boot um mich zu retten." });
        textDic.Add(TextToPlay.StoryWon, new List<string> { "Winner" });

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
        // Load Text from JSON File
        TextItem TextContainer = new TextItem();
        TextContainer.pages = textDic[texttype]; //JsonUtility.FromJson<TextItem>(text);
        TextContainer.name = texttype.ToString();
        this.TextElement.StartDisplayText(this, TextContainer);
    }



    public void ClickEvent(){
        this.TextElement.ButtonClick();    
    }
}