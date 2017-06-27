using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Item
{
    #region Methods

    public override void Start()
    {
        this.SpritePath = @"InventoryItems/LowPolyArtStyleIcons/128px/Transparent/stone";
        base.Start();
    }

    #endregion // Methods
}
