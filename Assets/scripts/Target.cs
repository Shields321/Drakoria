using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private float health; // Health variable, serialized for Inspector    
        [SerializeField] private float attackDamage;
        [SerializeField] private float attackRange;  
        [SerializeField] private float attackCooldown;
        private float lastTimeAtk=0f;    
        private Player player;                          

        void Update(){
            if(player == null){
                player = FindObjectOfType<Player>();  // Find the Player component
                if (player == null) {
                    Debug.LogError("Player not found!");
                }
            }

            if(player != null && isInRange()){
                //Debug.Log("Atk");
                attack(attackDamage);
            }
        }
        
        private void attack(float dmg){
            if(player != null){
                if(Time.time >=attackCooldown+lastTimeAtk){
                    Debug.Log("Target is attacking the player!");
                    player.updateHp(-attackDamage); // Apply damage to the player
                    lastTimeAtk = Time.time; // Reset the attack timer
                }
            }            
        }

        private bool isInRange(){   
            Transform playerTransform = player.getPlayerTransform();                           
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange){
                return true;
            }
            return false;
        }

        public void TakeDamage(float damage){
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

        private void HandleDeath(){
            // Drop item before destroying the target
            DropItem dropItemScript = GetComponent<DropItem>();
            if (dropItemScript != null)
            {
                dropItemScript.DropItemNow(); // Call a method to handle the drop
            }

            Debug.Log($"{gameObject.name} has been destroyed.");
            Destroy(gameObject); // Destroy the target when health is 0
        }                
    }
}
