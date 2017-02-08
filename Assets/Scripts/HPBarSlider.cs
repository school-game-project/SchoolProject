using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarSlider : MonoBehaviour
{
    private Slider _Slider;

 	void Start ()
    {
        this._Slider = (Slider)this.GetComponent<Slider>();
        //this._Slider.onValueChanged.AddListener(HPBarSliderChangeColour);
    }
    
    public void HPBarSliderChangeColour()
    {
        if (_Slider.value < 30)
            this._Slider.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0, 255);

        else if (_Slider.value < 70)
            this._Slider.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 0, 255);

        else
            this._Slider.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(0, 255, 0, 255);
    }
}