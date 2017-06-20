using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Costs;
    public string Type;
    public TMPro.TextMeshProUGUI Percent;
    public GameObject Disabled;

    public delegate void UpgradeHandler(UpgradeItem item);
    public event UpgradeHandler OnBuy;

    public void BuyItem()
    {
        OnBuy(this);
    }

    public void ActivateMe(int gold)
    {
        if(gold >= int.Parse(Costs.text))
        {
            Disabled.SetActive(false);
        }
        else
        {
            Disabled.SetActive(true);
        }
    }
	
}
