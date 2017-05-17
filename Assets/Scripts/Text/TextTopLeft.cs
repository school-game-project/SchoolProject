using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;


abstract public class TextTopLeft : TextItem
{
    public TextTopLeft():base()
    {
        this.boxPosition = GameObject.FindWithTag("TextTopLeft");
    }

    override protected Text GetTextElement(){
        return this.boxPosition.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
    }


}

