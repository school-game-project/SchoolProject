using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	private void Start ()
    {
        InitInventorySlots();
	}

    private void InitInventorySlots()
    {
        Vector3 v = this.transform.GetChild(0).GetChild(0).GetChild(0).localPosition;
        Vector3 v1 = this.transform.GetChild(0).GetChild(0).GetChild(0).position;

        GameObject go =  (GameObject)Resources.Load(@"Interface/InventoryUI/Slot");

        GameObject go2 = Instantiate(go);
    }
}