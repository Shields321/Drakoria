using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public Transform player;
        public float health;
        public float stamina;
        public float atk;

        void Start(){
            player = transform;
        }
        void Update()
        {            
            ifDead(); // Call the death check method
        }
        public float getHealth(){return health;}
        public Transform getPlayerTransform(){return player;}
        public void updateHp(float hpChange)
        {
            // Update the player's health by adding/subtracting the hpChange
            this.health += hpChange;
            Debug.Log("Player's Health updated: " + this.health);
        }

        private void ifDead()
        {
            if (this.health <= 1)
            {
                Debug.Log("Player is dead!");
                Destroy(gameObject); // Destroy the player game object when health is below 1
            }
        }
    }
}
