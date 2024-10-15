using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI components
namespace Game{
    public class DisplayStats : MonoBehaviour
    {
        public Text healthText; // Reference to the Text component for displaying health
        public Text timeText;
        public Text levelText;
        private Player player;
        private float gameTime;

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
            gameTime += Time.deltaTime;
            updateHealth();
            updateTime();
            updateLvl();
        }
        private void updateHealth()
        {
            if (player != null)
            {
                // Continuously update the text with player's current health
                healthText.text = "Health: " + player.health.ToString();
            }
        }
        private void updateTime()
        {            
            float minutes = Mathf.FloorToInt(gameTime / 60);
            float seconds = Mathf.FloorToInt(gameTime % 60);
            timeText.text = string.Format("Time: {0:00}:{1:00}",minutes,seconds);
        }
        private void updateLvl()
        {
            if (player != null) { 
                levelText.text = "Level: " + player.getLevel().ToString();
            }
                
        }
    }
}
