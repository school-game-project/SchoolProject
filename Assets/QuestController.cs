using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class QuestController : MonoBehaviour
{
    public TextMeshProUGUI textRessource1;
    public TextMeshProUGUI textRessource2;

    private int maxRessource1;
    private int maxRessource2;

    private int actualRessource1;
    private int actualRessource2;

    private bool doneRessource1;
    private bool doneRessource2;

    private Inventory inventory;

    private void Awake()
    {
        maxRessource1 = 150;
        maxRessource2 = 120;
        doneRessource1 = false;
        doneRessource2 = false;
    }

    private void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        inventory.GotNewItemsToShow += ItemsFound;

        this.SetUpText();
        
    }

    private void SetUpText()
    {
        this.textRessource1.text = this.actualRessource1 + "/" + this.maxRessource1;
        this.textRessource2.text = this.actualRessource2 + "/" + this.maxRessource2;

        if(actualRessource1 < maxRessource1)
        {
            this.textRessource1.color = new Color32(255, 0, 0, 255);
        }
        else if (actualRessource1 >= maxRessource1)
        {
            this.textRessource1.color = new Color32(0, 255, 0, 255);
        }

        if (actualRessource2 < maxRessource2)
        {
            this.textRessource2.color = new Color32(255, 0, 0, 255);
        }
        else if(actualRessource2 >= maxRessource2)
        {
            this.textRessource2.color = new Color32(0, 255, 0, 255);
        }

    }

    private void ItemsFound(object[] Items)
    {
        switch(Items[0].ToString())
        {
            case "Wood":
                this.actualRessource1 += (int)Items[1];
                break;
            
            default:
                this.actualRessource2 += (int)Items[1];
                break;
        }
        SetUpText();
    }
}
