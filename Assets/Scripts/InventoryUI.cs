using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    #region Fields & Props

    public GameObject Slot;
    public GameObject contentBox;
    public Transform originalSlot, selectedSlot, selectedItem;
    public int AmountOfSlots;

    #endregion // Fields & Props

    #region Methods

    private void Start()
    {
        this.GetSlots();
       
        GameObject.FindWithTag("Player").GetComponent<Inventory>().GoldChanged += GameObject.FindWithTag("GoldAmount").GetComponent<GoldUIController>().SetGold;
        GameObject.FindWithTag("GameController").GetComponent<GameController>().InventoryClone = this;

        this.SetShowingThis();
    }

    #region Init

    public void SetShowingThis()
    {
        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);

        else
            this.gameObject.SetActive(true);
    }

    private void GetSlots()
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        for (int i = 0; i < contentBox.transform.childCount; i++)
        {
            inventory.Slots.Add(contentBox.transform.GetChild(i).GetComponent<Slot>(), null);
            inventory.GotItem += contentBox.transform.GetChild(i).GetComponent<Slot>().AddItem;
        }
    }
    
    #endregion // Init

    #endregion // Methods
}