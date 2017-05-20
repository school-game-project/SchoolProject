using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextElement : MonoBehaviour
{
	private List<String> text = new List<String>();
    public TextItem activeText;
    public GameObject TextLeftTop;
	protected int currentPage = 0;
	protected int textOffset = 0;
    protected bool inAction = false;

    void Start(){
    }

	public void SetGraphicIcon()
	{

	}

    public void StartDisplayText(TextItem textDataClass)
	{
        this.activeText = textDataClass;
        this.TextLeftTop.SetActive(true);
        this.inAction = true;
		StartCoroutine(Timer(0.2f));
	}

	virtual public void ButtonClick()
	{

        if(this.activeText.pages.Count-1 > this.currentPage){
            if(this.inAction){
                this.inAction = false;
            }
            this.textOffset = 0;
			this.currentPage++;
            this.inAction = true;
			StartCoroutine(Timer(0.01f));
        }else{
            this.CancelDisplay();
        }

	}

	virtual public void CancelDisplay()
	{
        this.TextLeftTop.SetActive(false);
        this.inAction = false;
        this.currentPage = 0;
        this.textOffset = 0;
        this.activeText = null;

	}

    // Text Generator

	public void GenerateTextOutput()
	{
        // Content of current Page

        if (this.textOffset <= this.activeText.pages[this.currentPage].Length)
        {
            this.GetComponent<Text>().text = this.GetPassageByOffset();
            this.textOffset++;
            if(this.inAction){
    		    StartCoroutine(Timer(0.01f));
            }else{
                this.inAction = false;
            }
        }
	}


    private string GetPassageByOffset(){
        string text_passage = "";
        string full_text = this.activeText.pages[this.currentPage];
        int i = 0;

        foreach (char c in full_text){
            if (i < this.textOffset){
                text_passage += c;    
            }
            i++;
        }
        return text_passage;
   }


	virtual protected IEnumerator Timer(float waitTime)
	{

		yield return new WaitForSeconds(waitTime);
		this.GenerateTextOutput();
	}
}

