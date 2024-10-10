using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace Game
{

    public class ExeAbilities : MonoBehaviour
    {        
        public Transform player;   // Reference to the player’s transform
        private Abilities abilities;
        private float abilityCooldown = 1f;
        private float timer = 0f;
        private void Awake()
        {
            Debug.Log("Awake called");
            player = transform; // Assign the player transform to the current GameObject's transform
                                
            abilities = player.GetComponent<Abilities>();// Find the Abilities component attached to the player GameObject
            if (abilities == null)
            {
                Debug.LogError("Abilities component not found on the player GameObject.");
            }
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= abilityCooldown)
            {
                ExecuteAbility();
                timer = 0f;
            }
        }

        public void ExecuteAbility()
        {
            // Ensure abilities is not null before invoking the method
            if (abilities != null)
            {
                abilities.DevilHat();
            }
            else
            {
                Debug.LogWarning("Abilities component is not assigned.");
            }
        }
    }
}
