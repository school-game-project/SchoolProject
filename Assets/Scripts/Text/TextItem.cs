using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class TextItem : MonoBehaviour
{
    protected GameObject boxPosition;
	protected List<String> text = new List<String>();
    protected int currentPage = 0;
    protected int textOffset = 0;

    public TextItem()
    {
        Debug.Log("foobar");
	}

    virtual public void SetGraphicIcon(){
        
    }

    virtual public void StartDisplay(){
        StartCoroutine(Timer(0.2f));

	}

	virtual public void ButtonClick()
	{

	}

	virtual public void CancelDisplay(){
        
    }

    abstract protected Text GetTextElement();


	public void GenerateTextOutput()
	{
		// Content of current Page
        String page_content = this.text[this.currentPage];

		Text textbox = this.GetTextElement();
		Debug.LogError(textbox);

		//a.text = "A";
	}


	virtual protected IEnumerator Timer(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		this.GenerateTextOutput();
	}
}

