using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryController : MonoBehaviour
{   
    public GameObject depthCamera;
    public GameObject inventoryCanvas;
    public Transform gameObjectHolder;
    public float distanceFromCamera = 50f;
    public int index = 0;
    public List<ItemSO> lootList;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public void OpenLoot(List<ItemSO> lootList) {
        this.lootList = lootList;
        InstantiatePrefab(lootList[0]);
        depthCamera.SetActive(true);
        inventoryCanvas.SetActive(true);
    }

    public void CloseLoot() {
        inventoryCanvas.SetActive(false);
        depthCamera.SetActive(false);
        Destroy(gameObjectHolder.GetChild(0).gameObject);
    }
    
    public void Navigate(int direction) {
        index += direction;
        if(direction == 1 && index > (lootList.Count - 1)) {
            index = 0;
            Destroy(gameObjectHolder.GetChild(0).gameObject);
            InstantiatePrefab(lootList[0]);
        }else if(direction == -1 && index < 0){
            index = lootList.Count - 1;
            Destroy(gameObjectHolder.GetChild(0).gameObject);
            InstantiatePrefab(lootList[lootList.Count - 1]);
        }else {
            Destroy(gameObjectHolder.GetChild(0).gameObject);
            InstantiatePrefab(lootList[index]);
        }
    }

    public void InstantiatePrefab(ItemSO itemSO) {
        SetNameAndDescription(itemSO);

        GameObject clone = Instantiate(itemSO.item, gameObjectHolder, true);
        clone.transform.localPosition = new Vector3(0, 0, distanceFromCamera);
        clone.transform.rotation = itemSO.poseRotation;
        clone.transform.localScale = new Vector3(itemSO.poseScale, itemSO.poseScale, itemSO.poseScale);
        clone.layer = LayerMask.NameToLayer("Depth");
        clone.AddComponent<RotateGameObject>();
    }

    public void SetNameAndDescription(ItemSO itemSO) {
        itemName.text = itemSO.name;
        itemDescription.text = itemSO.description;
    }

    public void TakeLoot() {
        
    }
}
