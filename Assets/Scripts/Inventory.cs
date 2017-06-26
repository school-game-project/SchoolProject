using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Fields & Props

    private int _Gold;
    public int Gold
    {
        get { return _Gold; }
        private set { _Gold = value;
            this.RaiseGoldChanged(this._Gold); }
    }
    
    private Dictionary<Slot, Item> _Slots;
    public Dictionary<Slot, Item> Slots
    {
        get { return _Slots; }
        set { _Slots = value; }
    }

    private int RandomWood
    {
        get { return UnityEngine.Random.Range(2, 6); }
    }

    private int RandomStone
    {
        get { return UnityEngine.Random.Range(1, 4); }
    }

    private int RandomGold
    {
        get { return UnityEngine.Random.Range(1, 3); }
    }

    private bool HasWoodGold
    {
        get { return UnityEngine.Random.Range(1, 11) == 1; }
    }

    private bool HasStoneGold
    {
        get { return UnityEngine.Random.Range(1, 6) == 1; }
    }
    
    #endregion // Fields & Props

    #region Methods

    private void Awake()
    {
        ((ActionDetecter)gameObject.GetComponent<ActionDetecter>()).MineFinished += this.GettingItem;
        this._Slots = new Dictionary<Slot, Item>(16);
    }

    public void AddItem(Item p_Item)
    {
        if (p_Item != null)
        {
            foreach (Slot keySlot in this._Slots.Keys)
                if (this._Slots[keySlot] != null && this._Slots[keySlot].GetType() == p_Item.GetType())
                {
                    object[] temp = this.GetAmountsOfItem(p_Item);

                    this.Gold += (int)temp[2];
                    this._Slots[keySlot].Amount += (int)temp[1];

                    this.RaiseGotNewItemsToShow(temp);

                    this.RaiseGotItem(this._Slots[keySlot]);
                    return;
                }
        
            this.AddNewItem(p_Item);
        }
    }

    public void AddNewItem(Item p_Item)
    {
        if (p_Item != null)
            foreach (Slot keySlot in this._Slots.Keys)
            {
                if (this._Slots[keySlot] == null)
                {
                    object[] temp = this.GetAmountsOfItem(p_Item);

                    p_Item.Amount = (int)temp[1];
                    this.Gold += (int)temp[2];
                    this._Slots[keySlot] = p_Item;
                    this._Slots.Where(s => s.Value == p_Item).FirstOrDefault().Key.GetComponent<Slot>().MyItem = p_Item;

                    this.RaiseGotNewItemsToShow(temp);

                    this.RaiseGotItem(p_Item);
                    return;
                }
            }
    }
    
    public void RemoveItem(Item p_Item)
    {
        // TODO implement RemoveItem

        //var query = this._Items.Where(i => i.GetType() == p_Item.GetType());

        //if (query.Count() > 0)
        //    //this.RemovedItem(p_Item);

        //if (query.Count() == 1)
        //    this._Items.Remove(query.ToArray()[0]);
    }

    private object[] GetAmountsOfItem(Item p_Item)
    {
        object[] temp = new object[3];

        temp[0] = p_Item.GetType();

        if (p_Item is Wood)
        {
            if (this.HasWoodGold)
            {
                int gold = this.RandomGold;
                temp[1] = this.RandomWood * gold;
                temp[2] = gold;
            }

            else
            {
                temp[1] = this.RandomWood;
                temp[2] = 0;
            }
        }

        else
        {
            if (this.HasStoneGold)
            {
                int gold = this.RandomGold;
                temp[1] = this.RandomStone * gold;
                temp[2] = gold;
            }

            else
            {
                temp[1] = this.RandomStone;
                temp[2] = 0;
            }
        }

        return temp;
    }

    public void DecreaseGold(int p_Gold)
    {
        if (this.Gold >= p_Gold)
            this.Gold = this.Gold - p_Gold;
    }

    #endregion // Methods

    #region Events & Handler

    public delegate void ItemEventHandler(Item p_NewItem);
    public delegate void ItemUIEventHandler(object[] p_AmountsOfItems);
    public delegate void GoldEventHandler(int p_Gold);

    public event ItemEventHandler GotItem;
    public event ItemUIEventHandler GotNewItemsToShow;
    public event GoldEventHandler GoldChanged;

    private void RaiseGoldChanged(int p_Gold)
    {
        if (this.GoldChanged != null)
            this.GoldChanged(p_Gold);
    }

    private void RaiseGotItem(Item p_Item)
    {
        if (this.GotItem != null)
            this.GotItem(p_Item);
    }

    private void RaiseGotNewItemsToShow(object[] p_AmountsOfItems)
    {
        if (this.GotNewItemsToShow != null)
            this.GotNewItemsToShow(p_AmountsOfItems);
    }

    public void GettingItem(GameObject p_ItemHolder)
    {
        string itemHolderName = p_ItemHolder.tag == "Stone" ? "Rock" : p_ItemHolder.tag;

        if (p_ItemHolder.transform.parent.FindChild(String.Format("Master" + itemHolderName)).GetComponent<Item>() != null)
            this.AddItem(p_ItemHolder.transform.parent.FindChild(String.Format("Master" + itemHolderName)).GetComponent<Item>());
    }

    public void RemovingItem(object p_Item)
    {
        // TODO removing event method
    }

    #endregion // Events & Handler
}