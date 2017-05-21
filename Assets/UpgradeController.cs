using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public List<UpgradeItem> AllUpgradeItems = new List<UpgradeItem>();

    private Inventory Inventory;

    private void Awake()
    {
        foreach(UpgradeItem item in AllUpgradeItems)
        {
            item.OnBuy += BuyAction;

            item.Costs.text = "1";
            item.Percent.text = "+" + 5 + "%";

            item.ActivateMe(0);
        }
    }

    private void Start()
    {
        Inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        Inventory.GoldChanged += ActivateUpgradeItems;
    }

    private void BuyAction(UpgradeItem item)
    {
        int costs = int.Parse(item.Costs.text);
        
        if (Inventory.Gold >= costs)
        {
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


            Inventory.DecreaseGold(costs);
        }
    }

    private void ActivateUpgradeItems(int gold)
    {
        foreach (UpgradeItem item in AllUpgradeItems)
        {
            item.ActivateMe(gold);
        }
    }

}
