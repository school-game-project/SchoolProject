using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Map;
public class ActionDetecter : MonoBehaviour {

    bool canTrigger = false;
    GameObject toMine;
    bool blocked = false;
    public delegate void MineEventHandler(GameObject target);
    public event MineEventHandler MineTriggered;

    
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Event trigger
            if (!blocked)
            {
                MineTriggered(toMine);
                blocked = true;
            }
            //TODO MineStopped nach timeinterval triggern
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        canTrigger = true;
        toMine = coll.gameObject;
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider coll)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        canTrigger = false;
    }

}
