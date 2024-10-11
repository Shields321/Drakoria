using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody2D rb;  // Reference to the Rigidbody2D component
        public float speed; // Speed of the player
        public Camera mainCamera; // Reference to the main camera
        private Vector2 movement; // Movement vector for 2D

        void Start()
        {
            mainCamera = Camera.main; // Assign the main camera
        }

        void Update()
        {
            // Get input for horizontal and vertical movement
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // Set movement direction based on input
            movement = new Vector2(x, y).normalized;
            
        }

        // FixedUpdate is called once per physics frame
        void FixedUpdate()
        {
            // Move the player
            MovePlayer();

            // Update the camera position to follow the player
            FollowPlayer();
        }

        private void MovePlayer()
        {
            // If movement is detected, move the player
            if (movement != Vector2.zero)
            {
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                // Stop the player by setting its velocity to zero
                rb.velocity = Vector2.zero;
            }
        }

        private void FollowPlayer()
        {
            // Calculate the target position for the camera
            Vector3 targetCameraPosition = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);

            // Smoothly move the camera to the target position
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetCameraPosition, Time.deltaTime * speed);
        }
    }
}
