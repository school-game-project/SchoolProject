using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootItem : MonoBehaviour
{
    public Image itemImage;
    public Text itemAmount;

    public void SetMe(Sprite sprite, int amount)
    {
        itemImage.sprite = sprite;

        if(amount == 0)
            itemAmount.text = "";

        else
            itemAmount.text = amount.ToString();

    }
	
}
