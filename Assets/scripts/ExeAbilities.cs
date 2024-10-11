using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace Game
{

    public class ExeAbilities : MonoBehaviour
    {        
        public Transform player;
        private Abilities abilities;
        private Dictionary<string, float> abilityCooldown = new Dictionary<string, float>();
        private float timer = 0f;

        private void Awake()
        {
            Debug.Log("Awake called");
            player = transform; // Assign the player transform to the current GameObject's transform
            setCooldowns();
            abilities = player.GetComponent<Abilities>();// Find the Abilities component attached to the player GameObject            

            if (abilities == null)
            {
                Debug.LogError("Abilities component not found on the player GameObject.");
            }
        }

        void Update()
        {
            timer += Time.deltaTime;            
            if (timer >= abilityCooldown["Aura"])
            {
                ExecuteAbility();
                timer = 0f;
            }
        }
        private void setCooldowns(){
            abilityCooldown["Aura"] = 2f; //set the ability cooldown
        }

        public void ExecuteAbility()
        {
            // Ensure abilities is not null before invoking the method
            if (abilities != null){
                abilities.DevilHat();
            }
            else{
                Debug.LogWarning("Abilities component is not assigned.");
            }
        }
    }
}
