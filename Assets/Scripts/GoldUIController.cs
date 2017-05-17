using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUIController : MonoBehaviour
{
    public void AddGold(object[] p_AmountsOfItem)
    {
        this.transform.GetComponent<Text>().text = (int.Parse(this.transform.GetComponent<Text>().text) + (int)p_AmountsOfItem[2]).ToString();
    }
}
