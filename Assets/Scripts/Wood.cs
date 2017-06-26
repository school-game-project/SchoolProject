using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item
{
    #region Fields & Props

    public override string SpritePath { get; protected set; }

    #endregion // Fields & Props

    #region Methods

    public override void Start()
    {
        this.SpritePath = @"InventoryItems/LowPolyArtStyleIcons/128px/Transparent/wood";
        base.Start();
    }

    #endregion // Methods
}
