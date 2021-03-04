using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Loot Heaven/Item", order = 0)]
public class ItemSO : ScriptableObject {
    public GameObject item;
    [Range(0,100)]
    public float spawnChance;
    public Quaternion poseRotation;
    public float poseScale; 
    [TextArea(5,10)]
    public string description; 

    public bool isSpawned() {
        int randomNumber = Random.Range(0,100);
        if(randomNumber < spawnChance)
            return true;
        return false;
    }
}
