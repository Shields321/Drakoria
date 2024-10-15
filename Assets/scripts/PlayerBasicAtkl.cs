using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerBasicAtkl : MonoBehaviour
    {
        [SerializeField] private Target target;  // Current target to attack
        [SerializeField] private GameObject atkDisplay;  // Prefab of the attack indicator
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float range = 2f;  // Range of the attack
        private Player player;
        private float baseDmg;
                  
        private GameObject display;  // The instantiated attack indicator
        private float timer = 0f;

        private void Start()
        {
            player = GetComponent<Player>();
            initAtkDisplay();  // Initialize the attack display when the player spawns
        }

        void Update()
        {
            baseDmg = player.getAtk();
            timer += Time.deltaTime;
            // Find all targets within range 
            findAllTargets();  // Update the current target
            // Update the attack display's position and rotation
            MoveAtkDisplay();

            // Check if it's time to attack
            if (timer >= 0.5)
            {
                ApplyDamageToTarget();  // Apply damage to the target if close enough
                timer = 0f;  // Reset timer
            }
                      
        }

        private void MoveAtkDisplay()
        {
            if (display == null) return;  // Ensure display is instantiated

            // Get the mouse position in world space
            Vector3 mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0f; // Ensure it's 2D, set Z-axis to 0

            // Get the direction from the player to the mouse position
            Vector3 direction = (mousePos - transform.position).normalized;

            // Set the position of display a certain distance (range) in the direction of the mouse
            display.transform.position = transform.position + direction * range;

            // Rotate the display to point towards the mouse
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            display.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        private void initAtkDisplay()
        {
            display = Instantiate(atkDisplay, transform.position, Quaternion.identity); // Store reference to instantiated object
            display.SetActive(true); // Ensure the display is active
        }

        private void findAllTargets()
        {
            Target[] targets = FindObjectsOfType<Target>();
            float closestDistance = Mathf.Infinity;
            Target closestTarget = null;

            if (targets.Length > 0)
            {
                foreach (Target t in targets)
                {
                    float distance = Vector2.Distance(transform.position, t.transform.position);
                    if (distance < closestDistance && distance < range)
                    {
                        closestDistance = distance;
                        closestTarget = t;
                    }
                }
                target = closestTarget;  // Update the current target
            }
        }

        private void ApplyDamageToTarget()
        {
            if (target != null)
            {
                // Calculate the distance from the attack display to the target
                float distanceToTarget = Vector2.Distance(display.transform.position, target.transform.position);                
                // Check if within damage threshold
                if (distanceToTarget <= range)
                {                    
                    target.TakeDamage(baseDmg);  // Deal damage to the target
                    // Optionally destroy the atkDisplay after hitting or keep it for the next attack
                    // Destroy(display); // Uncomment if you want to destroy it after hitting
                }
            }
        }
    }
}
