using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GoldUIController : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<TextMeshProUGUI>().text = 0 + "";
    }

    public void AddGold(object[] p_AmountsOfItem)
    {
        this.transform.GetComponent<TextMeshProUGUI>().text = (int.Parse(this.transform.GetComponent<TextMeshProUGUI>().text) + (int)p_AmountsOfItem[2]).ToString();
    }
}
