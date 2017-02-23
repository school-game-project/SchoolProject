using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryUI : MonoBehaviour
{
    #region Fields & Props

    public Vector2 _InventorySize;
    public Transform originalSlot, selectedSlot, selectedItem;

    #endregion // Fields & Props

    #region Methods

    private void Start()
    {
        InitInventoryBackGround();
        InitInventorySlots();
    }

    #region Init

    private void InitInventoryBackGround()
    {
        Vector2 parentSize = this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;

        GameObject background = (GameObject)Instantiate(Resources.Load(@"Interface/InventoryUI/Background"));

        background.transform.parent = this.transform.GetChild(0).transform;
        background.name = "Background";
        background.GetComponent<RectTransform>().sizeDelta = new Vector2(parentSize.y * 0.75f, parentSize.y * 0.75f);
        background.GetComponent<RectTransform>().anchoredPosition = new Vector3((parentSize.x / 4), 0); // relative angabe bei y-wert (parentSize.y / 2) - (parentSize.y / 2)
    }

    private void InitInventorySlots()
    {
        Vector2 parentSize = this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta;

        float borderX = parentSize.x * 0.12f;
        float borderY = parentSize.y * 0.12f;

        Vector2 childSize = new Vector2(parentSize.x - 2 * borderX, parentSize.y - 2 * borderY);
        Vector2 slotDistance = new Vector2(childSize.x / this._InventorySize.x, childSize.y / this._InventorySize.y);

        GameObject go = (GameObject)Resources.Load(@"Interface/InventoryUI/Slot");

        for (int x = 0; x < this._InventorySize.x; x++)
            for (int y = 0; y < this._InventorySize.y; y++)
            {
                GameObject slot = Instantiate(go);

                slot.transform.parent = this.transform.GetChild(0).GetChild(0).transform;
                slot.name = String.Format("slot_{0}_{1}", x, y);
                slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(borderX + slotDistance.x / 2 + x * slotDistance.x, -(borderY + slotDistance.y / 2 + y * slotDistance.y));
                slot.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(childSize.x / this._InventorySize.x * 0.95f, childSize.y / this._InventorySize.y * 0.95f);
            }
    }

    #endregion // Init

    #endregion // Methods
}