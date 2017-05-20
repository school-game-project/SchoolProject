using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public List<UpgradeItem> AllUpgradeItems = new List<UpgradeItem>();

    private int gold;

    private void Awake()
    {
        foreach(UpgradeItem item in AllUpgradeItems)
        {
            item.OnBuy += BuyAction;

            item.Costs.text = "1";
            item.Percent.text = "+" + 5 + "%";
        }
    }

    private void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<Inventory>().GotNewItemsToShow += AddGold;
    }

    private void BuyAction(UpgradeItem item)
    {
        int costs = int.Parse(item.Costs.text);
        
        if (gold >= costs)
        {
            gold -= costs;
            switch (item.Type)
            {
                case "wood":
                    break;
                case "stone":
                    break;
                default:
                    break;
            }
            item.Costs.text = "" + costs * 2;
            item.Percent.text = "+" + 5 * int.Parse(item.Costs.text) + "%";
            
        }
    }

    private void AddGold(object[] item)
    {
        this.gold = (int)item[2];
    }

}
