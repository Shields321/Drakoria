using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private float health; // Health variable, serialized for Inspector

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
            // Handle the target's death (e.g., play animation, effects, etc.)
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
