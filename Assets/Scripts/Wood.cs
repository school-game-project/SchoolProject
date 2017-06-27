using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item
{
    #region Methods

    public override void Start()
    {
        this.SpritePath = @"InventoryItems/LowPolyArtStyleIcons/128px/Transparent/wood";
        base.Start();
    }

    #endregion // Methods
}
