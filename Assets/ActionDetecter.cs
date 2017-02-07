using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDetecter : MonoBehaviour {

    bool canTrigger = false;
    string type = ""; 
        
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Abbau-Event Triggern
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        switch (coll.tag)
        {
            case "Tree":
                //Keypress möglich machen
                canTrigger = true;
                type = "Tree";
                //Hinweis anzeigen
                this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
            case "Stone":
                //Keypress möglich machen
                canTrigger = true;
                type = "Stone";
                //Hinweis anzeigen
                this.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        //Hinweis verstecken
        this.transform.GetChild(0).gameObject.SetActive(false);
        //Keypress deaktivieren 
        canTrigger = false;
    }

}
