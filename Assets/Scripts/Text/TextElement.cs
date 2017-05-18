using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextElement : MonoBehaviour
{
	private List<String> text = new List<String>();
    public TextItem activeText;
	protected int currentPage = 0;
	protected int textOffset = 0;

    void Start(){
    }

	public void SetGraphicIcon()
	{

	}

    public void StartDisplayText(TextItem textDataClass)
	{
        this.activeText = textDataClass;
		StartCoroutine(Timer(0.2f));
	}

	virtual public void ButtonClick()
	{

	}

	virtual public void CancelDisplay()
	{

	}

	//abstract protected Text GetTextElement();


	public void GenerateTextOutput()
	{
		// Content of current Page

        this.GetComponent<Text>().text = this.activeText.pages[this.currentPage];

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

