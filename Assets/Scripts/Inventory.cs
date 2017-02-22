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

    #endregion // Fields & Props

    #region Methods

    void Start()
    {
        ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineFinished += this.GettingItem;
    }

    public void AddItem(Item p_Item)
    {
        if (this._Items == null)
        {
            Vector2 inventorySize = ((InventoryUI)GameObject.Find("InventoryUI").GetComponent(typeof(InventoryUI)))._InventorySize;
            this._Items = new Item[(int)inventorySize.x, (int)inventorySize.y];
        }

        if (p_Item != null)
            for (int i = 0; i < this._Items.GetLength(0); i++)
                for (int j = 0; j < this._Items.GetLength(1); j++)
                {
                    if (this._Items[i, j] != null && this._Items[i, j].GetType() == p_Item.GetType())
                    {
                        this._Items[i, j].Amount++;
                        this.GotItem(this._Items[i, j]);
                        return;
                    }

                    else if (i == this._Items.GetLength(0) - 1 && j == this._Items.GetLength(1) - 1)
                        this.AddNewItem(p_Item);
                }
    }

    public void AddNewItem(Item p_Item)
    {
        if (p_Item != null)
            for (int i = 0; i < this._Items.GetLength(0); i++)
                for (int j = 0; j < this._Items.GetLength(1); j++)
                    if (this._Items[i, j] == null)
                    {
                        this._Items[i, j] = p_Item;
                        this.SetItemToSlot(this._Items[i, j], new Vector2(i, j));
                        return;
                    }
    }

    private void SetItemToSlot(Item p_Item, Vector2 p_Coord)
    {
        GameObject slot = GameObject.FindGameObjectsWithTag("Slot").First(s => s.name == String.Format("slot_{0}_{1}", p_Coord.y, p_Coord.x));

        if (slot != null)
        {
            slot.GetComponent<Slot>().MyItem = p_Item;
            this.GotItem(p_Item);
        }
    }

    public void RemoveItem(Item p_Item)
    {
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