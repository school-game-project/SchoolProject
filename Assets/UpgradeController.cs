using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public delegate void UpgradeHandler();
    public event UpgradeHandler OnChopSpeed;
    public event UpgradeHandler OnMineSpeed;
    public event UpgradeHandler OnMoveSpeed;

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

    private void Update()
    {
       // this.transform.LookAt(Camera.main.transform);
    }

    private void BuyAction(UpgradeItem item)
    {
        int costs = int.Parse(item.Costs.text);
        
        if (Inventory.Gold >= costs)
        {
            switch (item.Type)
            {
                case "wood":
                    OnChopSpeed();
                    break;
                case "stone":
                    OnMineSpeed();
                    break;
                default:
                    OnMoveSpeed();
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
