using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Abilities : MonoBehaviour
    {
        [SerializeField] private GameObject target;  // Make it private but visible in the Inspector
        public Transform playerTransform;   // Reference to the player’s transform        
        private float distanceThreshold = 5f;
        
                
        public void auraOfProtection(Player player, int level) //this is not devil hat its the aura one
        {                
            float[] level_scale = {5,10,15,20,25,30}; 
            SetClosestTarget();
            float baseDamage = 5f; // Set base damage here
            float damageMultiplierFar = levelUpdate(level_scale,level);            
            float finalDmg = baseDamage; // Initialize final damage to base damage            
            // Calculate distance from player to target
            float distance = Vector2.Distance(playerTransform.position, target.transform.position);

            // Determine damage based on distance
            if (distance < distanceThreshold){
                damageMultiplierFar = 1.2f;
                finalDmg *= damageMultiplierFar;  // Increase damage if farther away
            }            

            // Ensure the target is valid before applying damage
            if (target != null){
                Target targetComponent = target.GetComponent<Target>();
                if (targetComponent != null){
                    targetComponent.TakeDamage(finalDmg);
                    Debug.Log(" Dealt damage: " + finalDmg);
                }
                else{
                    Debug.LogError("Target component not found on target GameObject.");
                }
            }
            else{
                Debug.LogWarning("Target is null.");
            }
        }        
        public float levelUpdate(float[] scale,int level){ //get a refrence to the player lvl
            
            float damageMult = 0;
            for(int i =0; i<5;i++){
                if(level == i+1){
                    damageMult = scale[i];  
                }
            }
            return damageMult;
        }
        public void SetClosestTarget()
        {
            // Find all targets in the scene
            Target[] targets = FindObjectsOfType<Target>();
            float closestDistance = Mathf.Infinity;
            Target closestTarget = null;

            foreach (Target t in targets)
            {
                float distance = Vector2.Distance(playerTransform.position, t.transform.position);
                if (distance < closestDistance & distance < distanceThreshold)
                {
                    
                    closestDistance = distance;
                    closestTarget = t;
                                        
                }
            }

            // Set the closest target
            target = closestTarget?.gameObject; // Use null conditional operator to avoid null reference
        }
    }
}
