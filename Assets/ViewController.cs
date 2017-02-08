using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

    private string activeView = "";
    private string state = "";

    //Statelist
    //0 => default
    //1 => slow
    //2 => fast
    //3 => MenuOpen
    //4 => InventoryOpen
    //5 => pause
    private List<string> states = new List<string>();//"default", "slow", "fast", "menuOpen", "inventoryOpen", "pause");
    //Viewlist
    //0 => HomeMenu
    //1 => Ingame
    //2 => Options
    //3 => Save
    //4 => Load
    //5 => 
    private List<string> views = new List<string>();//"homeMenu", "ingame", "options", "save", "load");

	// Use this for initialization
	void Start () 
	{
        this.activeView = this.views[0];
		this.state 		= this.states[0];

		this.Load (this.activeView,this.state);

	}

	public void Load(string nextView, string nextState)
	{
		this.activeView = nextView;
		this.state 		= nextState;

	}

}
