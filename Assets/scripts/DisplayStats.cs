using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI components
namespace Game{
    public class DisplayStats : MonoBehaviour
    {
        public Text healthText; // Reference to the Text component for displaying health
        private Player player;

        void Start() 
        {
            // Find the Player object and cache the reference
            player = FindObjectOfType<Player>();
            
            // Optional: Check if player reference is valid
            if (player == null)
            {
                Debug.LogError("Player not found in the scene.");
            }
        }

        void Update()
        {
            if (player != null)
            {
                // Continuously update the text with player's current health
                healthText.text = "Health: " + player.health.ToString();
            }
        }
    }
}
