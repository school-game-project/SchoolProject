using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Costs;
    public string Type;
    public TMPro.TextMeshProUGUI Percent;

    public delegate void UpgradeHandler(UpgradeItem item);
    public event UpgradeHandler OnBuy;

    public void BuyItem()
    {
        OnBuy(this);
    }
	
}
