using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;

public class Inventory : MonoBehaviour
{
    #region Fields & Props

    private Item[,] _Items;
    public Item[,] Items
    {
        get { return _Items; }
        set { _Items = value; }
    }

    private Dictionary<Slot, Item> _Slots;
    public Dictionary<Slot, Item> Slots
    {
        get { return _Slots; }
        set { _Slots = value; }
    }

    public Vector2 InventorySize;

    #endregion // Fields & Props

    #region Methods

    void Start()
    {
        ((ActionDetecter)gameObject.GetComponent<ActionDetecter>()).MineFinished += this.GettingItem;
        this._Slots = new Dictionary<Slot, Item>((int)(this.InventorySize.x * this.InventorySize.y));
    }

    public void AddItem(Item p_Item)
    {
        if (p_Item != null)
        {
            foreach (var item in this._Slots)
                if (item.Value != null && item.Value.GetType() == p_Item.GetType())
                {
                    item.Value.Amount++;
                    this.GotItem(item.Value);
                    return;
                }
        
            this.AddNewItem(p_Item);
        }
    }

    public void AddNewItem(Item p_Item)
    {
        if (p_Item != null)
            foreach (var item in this._Slots)
                if (item.Value == null)
                {
                    this._Slots[item.Key] = p_Item;
                    this._Slots.Where(s => s.Value == p_Item).FirstOrDefault().Key.GetComponent<Slot>().MyItem = p_Item;
                    this.GotItem(p_Item);
                    return;
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
    
    #endregion // Methods

    #region Events & Handler

    public delegate void ItemEventHandler(Item p_NewItem);
    
    public event ItemEventHandler GotItem;
    //public event ItemEventHandler RemovedItem;

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