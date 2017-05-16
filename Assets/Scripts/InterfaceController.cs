using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Slider staminaSlider;
    public Text staminaText;


    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();

        staminaSlider.maxValue = playerMovement.maxStamina;
        staminaSlider.minValue = 0;

        playerMovement.OnStaminaChanged += UpdateStaminaBarAndText;
    }
    

    private void UpdateStaminaBarAndText()
    {
        staminaSlider.value = playerMovement.stamina;

        staminaText.text = ((playerMovement.stamina / playerMovement.maxStamina) * 100).ToString("0") + "%";

        if (staminaSlider.value < staminaSlider.maxValue / 3)
            staminaSlider.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 0, 0, 255);

        else if (staminaSlider.value < (staminaSlider.maxValue / 3) * 2)
            staminaSlider.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 0, 255);

        else
            staminaSlider.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(0, 255, 0, 255);
    }
}
