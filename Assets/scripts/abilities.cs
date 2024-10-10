using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Abilities : MonoBehaviour
    {
        [SerializeField] private GameObject target;  // Make it private but visible in the Inspector
        public Transform player;   // Reference to the player’s transform
        private float distanceThreshold = 3f;


        public void DevilHat() //this is not devil hat its the aura one
        {
            SetClosestTarget();
            float baseDamage = 10f; // Set base damage here
            float damageMultiplierFar = 1.2f;
            float finalDmg = baseDamage; // Initialize final damage to base damage

            // Calculate distance from player to target
            float distance = Vector2.Distance(player.position, target.transform.position);

            // Determine damage based on distance
            if (distance < distanceThreshold)
            {
                finalDmg *= damageMultiplierFar;  // Increase damage if farther away
            }
            else
            {
                finalDmg *= 0f; // Reduce damage if close
            }

            // Ensure the target is valid before applying damage
            if (target != null)
            {
                Target targetComponent = target.GetComponent<Target>();
                if (targetComponent != null)
                {
                    targetComponent.TakeDamage(finalDmg);
                    Debug.Log(" Dealt damage: " + finalDmg);
                }
                else
                {
                    Debug.LogError("Target component not found on target GameObject.");
                }
            }
            else
            {
                Debug.LogWarning("Target is null.");
            }
        }

        public void SetClosestTarget()
        {
            // Find all targets in the scene
            Target[] targets = FindObjectsOfType<Target>();
            float closestDistance = Mathf.Infinity;
            Target closestTarget = null;

            foreach (Target t in targets)
            {
                float distance = Vector2.Distance(player.position, t.transform.position);
                if (distance < closestDistance)
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
