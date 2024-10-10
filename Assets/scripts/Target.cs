using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private float health; // Health variable, serialized for Inspector        

        public float getHealth() { return health; }

        public void TakeDamage(float damage)
        {
            health -= damage; // Reduce health by the damage amount
            if (health <= 0)
            {
                HandleDeath(); // Call the death handling method
            }
            else
            {
                Debug.Log($"Target HP: {health}"); // Log current health if not dead
            }
        }

        private void HandleDeath()
        {
            // Drop item before destroying the target
            DropItem dropItemScript = GetComponent<DropItem>();
            if (dropItemScript != null)
            {
                dropItemScript.DropItemNow(); // Call a method to handle the drop
            }

            Debug.Log($"{gameObject.name} has been destroyed.");
            Destroy(gameObject); // Destroy the target when health is 0
        }


        // Optional: Method to reset health, useful for respawning
        public void ResetHealth(float newHealth)
        {
            health = newHealth;
        }
    }
}
