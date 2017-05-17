using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    protected GameObject boxPosition;
	protected List<String> text = new List<String>();
    protected int currentPage = 0;
    protected int textOffset = 0;

    private string startText = "WASDWASDWASDWASDWASD WAS DWASDWASD W";

    public TextItem()
    {
        Debug.Log("foobar");
	}

    virtual public void SetGraphicIcon(){
        
    }

    public void StartDisplay(){
        
        StartCoroutine(Timer(0.2f));

	}

    public void StartDisplayStoryStart(StoryStart stStart)
    {
        startText = stStart.Text;
        StartCoroutine(Timer(0.2f));
    }

	virtual public void ButtonClick()
	{

	}

	virtual public void CancelDisplay(){
        
    }

    //abstract protected Text GetTextElement();


	public void GenerateTextOutput()
	{
        // Content of current Page
        this.GetComponent<Text>().text = this.startText;

		//Text textbox = this.GetTextElement();
		//Debug.LogError(textbox);

		//a.text = "A";
	}


	virtual protected IEnumerator Timer(float waitTime)
	{
        
		yield return new WaitForSeconds(waitTime);
		this.GenerateTextOutput();
	}
}

