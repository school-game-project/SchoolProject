using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextElement : MonoBehaviour
{
	private List<String> text = new List<String>();
    private TextItem activeText;
    private TextManager manager;
	private int currentPage = 0;
    private bool playTextAnimation = false;
    private bool inAction = false;

    public void StartDisplayText(TextManager manager, TextItem textDataClass)
	{
        this.manager = manager;

        if(!this.inAction){
			this.activeText = textDataClass;
			this.manager.GetTextBox().SetActive(true);
			this.inAction = true;
            this.clearText();
			StartCoroutine(TextOutpt());   
        }else{
            this.CancelDisplay();
        }
    }

    private void clearText(){
		this.GetComponent<Text>().text = "";
	}

    private string getPageText(){
        return this.activeText.pages[this.currentPage];
    }



    public void ButtonClick()
	{

        if(this.activeText.pages.Count-1 > this.currentPage){

            if(this.playTextAnimation){
                this.playTextAnimation = false;
            }else{
                this.currentPage++;
                StartCoroutine(TextOutpt());
            }

            if(this.activeText.pages.Count - 2 < this.currentPage){
	            GameObject TextButton = GameObject.FindWithTag("TextSystemButton");
	            TextButton.transform.GetChild(0).gameObject.SetActive(true);
	            TextButton.transform.GetChild(1).gameObject.SetActive(false);
            }
        }else{
            this.CancelDisplay();
        }

	}

	virtual public void CancelDisplay()
	{
        this.manager.GetTextBox().SetActive(false);
        this.inAction = false;
        this.currentPage = 0;
        this.activeText = null;
        this.playTextAnimation = false;
	}

	virtual protected IEnumerator TextOutpt()
    {
        if(this.inAction){
            this.clearText();
            this.playTextAnimation = true;
			foreach (char c in this.getPageText())
			{
	            this.GetComponent<Text>().text += c;

                if (this.playTextAnimation)
				{
					yield return new WaitForSeconds(0.01f); 
				}
				else
				{
					break;
                }
			}
            this.GetComponent<Text>().text = this.getPageText();
            this.playTextAnimation = false;
		}
	}
}

