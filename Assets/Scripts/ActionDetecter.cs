using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Map;

public class ActionDetecter : MonoBehaviour {

    bool canTrigger = false;
    GameObject toMine;
    bool blocked = false;
    float minestarted = 0;
    Animation animation;
    
    int mineDuration = 120;

    public delegate void MineEventHandler(GameObject target);

    public event MineEventHandler MineTriggered;
    public event MineEventHandler MineCanceled;
    public event MineEventHandler MineFinished;

    private void Start()
    {
        animation = ((Animation)this.gameObject.GetComponent("Animation"));
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Event trigger
            if (!blocked && canTrigger)
            {
                MineTriggered(toMine);
                blocked = true;
                minestarted = Time.time;

                this.transform.GetChild(1).gameObject.SetActive(true);
                animation.Play("orcdamage");
            }
            if (blocked)
            {
                if (Time.time - minestarted >= 2)
                {
                    MineFinished(toMine);
                    canTrigger = false;
                    blocked = false;
                    toMine = null;
                    this.transform.GetChild(0).gameObject.SetActive(false);
                    this.transform.GetChild(1).gameObject.SetActive(false);
                    animation.Stop("orcdamage");
                    animation.Play("orcwalk");
                }
            }
        }
        else
        {
            if (blocked)
            {
                MineCanceled(toMine);
                blocked = false;
                this.transform.GetChild(1).gameObject.SetActive(false);
                animation.Stop("orcdamage");
                animation.Play("orcwalk");
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Stone" || coll.tag == "Tree")
        {
            canTrigger = true;
            toMine = coll.gameObject;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        canTrigger = false;
        toMine = coll.gameObject;
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
        animation.Stop("orcdamage");
        animation.Play("orcwalk");
    }

}
