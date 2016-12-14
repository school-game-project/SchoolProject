using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    #region Fields & Props

    private List<Item> _Items;
    public List<Item> Items
    {
        get { return _Items; }
        set { _Items = value; }
    }

    #endregion // Fields & Props

    #region Methods

    void Start()
    {
        this._Items = new List<Item>();

        this.GotNewItem += ItemIncreaseAmount;
        this.RemovedItem += ItemDecreaseAmount; 
    }

    public void AddItem(Item p_NewItem)
    {
        var query = this._Items.Where(i => i.GetType() == p_NewItem.GetType());

        if (query.Count() == 0)
            this._Items.Add(p_NewItem);
        
        this.GotNewItem.Invoke(query.ToArray()[0]);
    }

    public void RemoveItem(Item p_Item)
    {
        var query = this._Items.Where(i => i.GetType() == p_Item.GetType());

        if (query.Count() > 0)
            this.RemovedItem(p_Item);

        if (query.Count() == 1)
            this._Items.Remove(query.ToArray()[0]);
    }

    public void ItemIncreaseAmount(Item p_Item)
    {
        p_Item.Amount++;
    }

    public void ItemDecreaseAmount(Item p_Item)
    {
        p_Item.Amount--;
    }
    
    #endregion // Methods

    #region Events & Handler

    public delegate void ItemEventHandler(Item p_NewItem);

    public event ItemEventHandler GotNewItem;
    public event ItemEventHandler RemovedItem;

    public void OnGotItem(object p_NewItem)
    {
        if (GotNewItem != null && p_NewItem is Item)
            GotNewItem(p_NewItem as Item);
    }
    public void OnRemovedItem(object p_Item)
    {
        if (RemovedItem != null && p_Item is Item)
            RemovedItem(p_Item as Item);
    }

    #endregion // Events & Handler
}