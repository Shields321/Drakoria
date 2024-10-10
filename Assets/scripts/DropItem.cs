using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class DropItem : MonoBehaviour
    {                
        public GameObject drop;
        public GameObject target;        
        private bool hasDropped = false;

        public void DropItemNow()
        {
            if (!hasDropped)
            {
                Vector3 spawnPosition = target.transform.position;
                Debug.Log("Dropping item at: " + spawnPosition); // Log the position
                GameObject spawnedItem = Instantiate(drop, spawnPosition, Quaternion.identity);

                // Check the spawned item's details
                Debug.Log("Spawned item: " + spawnedItem.name + " at position: " + spawnedItem.transform.position);

                hasDropped = true;
            }
        }
    }
}
