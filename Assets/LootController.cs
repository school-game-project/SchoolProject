using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{ 
    public GameObject ItemPrefab;
    public GameObject ItemContent;

    public Sprite wood;
    public Sprite stone;
    public Sprite gold;

    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        playerInventory.GotNewItemsToShow += ItemsFound;

        Hide();
    }

    private void ItemsFound(object[] Items)
    {
        GameObject item = Instantiate(ItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        item.transform.SetParent(ItemContent.transform);
        if(Items[0].ToString() == "Wood")
        {
            item.GetComponent<LootItem>().SetMe(wood, (int)Items[1]);
        }
        else
        {
            item.GetComponent<LootItem>().SetMe(stone, (int)Items[1]);
        }

        for(int i = 0; i < (int)Items[2]; i++)
        {
            GameObject goldItem = Instantiate(ItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            goldItem.transform.SetParent(ItemContent.transform);
            goldItem.GetComponent<LootItem>().SetMe(gold, 0);
        }

        Show();

        StartCoroutine(HideAfterTime(3.0f));

        ClearContent();
    }

    private void ClearContent()
    {
        foreach(Transform child in ItemContent.transform)
        {
            Destroy(child.gameObject, 3.0f);
        }

    }

    private IEnumerator HideAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Hide();
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private void Show()
    {
        this.gameObject.SetActive(true);
    }

}
