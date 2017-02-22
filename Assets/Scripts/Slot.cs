using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    #region Fields & Props

    private Item _MyItem;
    public Item MyItem
    {
        get { return _MyItem; }
        set { this._MyItem = value; }
    }

    public Sprite MySprite { get; set; }

    #endregion // Fields & Props

    #region Methods

    public void Start()
    {
        ((Inventory)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(Inventory))).GotItem += AddItem;
        this.tag = "Slot";
    }

    private void AddItem(Item p_Item)
    {
        if (this._MyItem != null && this._MyItem.GetType() == p_Item.GetType())
        {
            this.transform.GetChild(0).GetComponent<Text>().text = p_Item.Amount.ToString();

            if (this.transform.GetChild(1).GetComponent<Image>().sprite == null)
            {
                this.transform.GetChild(1).GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>(p_Item._SpritePath);
                this.transform.GetChild(1).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }
    }

    #endregion // Methods
}
