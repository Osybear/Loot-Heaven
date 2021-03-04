using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchable : MonoBehaviour
{   
    public InventoryController2 inventoryController;
    public List<ItemSO> itemList;
    public List<ItemSO> lootList;

    private void Awake() {
        //GenerateLoot();
    }

    private void GenerateLoot() {
        foreach(ItemSO itemSO in itemList) {
            if(itemSO.isSpawned())
                lootList.Add(itemSO);
        }
    }

    private void OnMouseDown() {
        Debug.Log("When the player clicks on searchable display items in inventory UI");
        //inventoryController.OpenLoot(lootList);
        inventoryController.OpenInventory(lootList);
    }
}
